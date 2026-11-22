using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public float[] passionDecayLevels;
    private int currentLevel = 0;

    public Canvas hudCanvas;
    private ProgressBarLogic passionProgressBar;

    public GameObject player;
    public GameObject girl;

    private PlayerLogic playerLogic;
    private GirlLogic girlLogic;

    public Canvas AngerGameOverPanel;
    public Canvas VictoryPanel;
    public Canvas PassionGameOverPanel;

    public AudioSource gameMusic;
    public AudioSource gameOverMusic;
    public AudioSource obsessedMusic;

    void Awake()
    {
        Transform passionPannel = hudCanvas.transform.Find("PassionPanel");
        passionProgressBar = passionPannel.transform.Find("PassionProgressBar").GetComponent<ProgressBarLogic>();
        playerLogic = player.GetComponent<PlayerLogic>();
        girlLogic = girl.GetComponent<GirlLogic>();

        AngerGameOverPanel.enabled = false;
        VictoryPanel.enabled = false;
        PassionGameOverPanel.enabled = false;
    }

    void FixedUpdate()
    {
        float passionDecay = passionDecayLevels[currentLevel];
        playerLogic.Passion -= passionDecay * Time.deltaTime;
        passionProgressBar.SetProgress(playerLogic.Passion);

        float distance = (player.transform.position - girl.transform.position).magnitude;

        playerLogic.CheckGirlPosition(girl.transform.position);
        girlLogic.CheckPlayerPosition(player.transform.position);

        UIUpdate();

        if (AngerGameOverPanel.enabled || VictoryPanel.enabled || PassionGameOverPanel.enabled)
            return;

        if (girlLogic.Anger >= 1.0f)
        {
            gameMusic.mute = true;
            gameOverMusic.mute = false;
            AngerGameOverPanel.enabled = true;
        }
        else if (playerLogic.Passion >= 1.0f)
        {
            gameMusic.mute = true;
            obsessedMusic.mute = false;
            VictoryPanel.enabled = true;
        }
        else if (playerLogic.Passion <= 0.0f)
        {
            gameMusic.mute = true;
            obsessedMusic.mute = false;
            PassionGameOverPanel.enabled = true;
        }
    }

    void UIUpdate()
    {
        float pingpong = Mathf.PingPong((Time.time) * 1.5f, 1);
        Transform passionPannel = hudCanvas.transform.Find("PassionPanel");
        float scale = Mathf.Lerp(1f, 1.1f, pingpong);
        passionPannel.localScale = new Vector3(scale, scale, scale);
    }

}