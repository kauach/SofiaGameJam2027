using System.Threading;
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
        passionProgressBar = hudCanvas.transform.Find("PassionProgressBar").GetComponent<ProgressBarLogic>();
    }

    void FixedUpdate()
    {
        float passionDecay = passionDecayLevels[currentLevel];

        player.Passion -= passionDecay * Time.deltaTime;

        passionProgressBar.SetProgress(player.Passion);
    }
}
