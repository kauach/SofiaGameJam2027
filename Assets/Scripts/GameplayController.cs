using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public float[] passionDecayLevels;
    private int currentLevel = 0;

    public Canvas hudCanvas;
    private ProgressBarLogic passionProgressBar;

    public PlayerLogic player;

    void Awake()
    {
        Transform passionPannel = hudCanvas.transform.Find("PassionPanel");
        passionProgressBar = passionPannel.transform.Find("PassionProgressBar").GetComponent<ProgressBarLogic>();
    }

    void FixedUpdate()
    {
        float passionDecay = passionDecayLevels[currentLevel];

        player.Passion -= passionDecay * Time.deltaTime;

        passionProgressBar.SetProgress(player.Passion);

        float pingpong = Mathf.PingPong((Time.time) * 1.5f, 1);
        Transform passionPannel = hudCanvas.transform.Find("PassionPanel");
        float scale = Mathf.Lerp(1f, 1.1f, pingpong);
        passionPannel.localScale = new Vector3(scale, scale, scale);
    }

}