using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    private Canvas personalCanvas;
    private Canvas hudCanvas;
    private ProgressBarLogic passionProgressBar;
    private TMP_Text playerText;
    private float uiCountdown = 3.0f;

    void Awake()
    {
        GameObject hudObject = GameObject.Find("HUD");
        hudCanvas = hudObject.GetComponent<Canvas>();
        passionProgressBar = hudObject.transform.Find("PassionProgressBar").GetComponent<ProgressBarLogic>();

        Transform tr = transform.Find("UI");
        if (tr != null)
        {
            personalCanvas = tr.gameObject.GetComponent<Canvas>();

            Transform tr2 = personalCanvas.transform.Find("Text");
            if (tr2 != null)
            {
                playerText = tr2.gameObject.GetComponent<TMP_Text>();
                playerText.text = gameObject.name;
            }

            personalCanvas.enabled = false;
        }
    }

    public void Update()
    {
        if (personalCanvas.enabled)
        {
            uiCountdown -= Time.deltaTime;
            if (uiCountdown < 0.0f)
                personalCanvas.enabled = false;
        }
    }

    public void TestInteraction(string text)
    {
        playerText.text = text;
        personalCanvas.enabled = true;
        uiCountdown = 3.0f;

        passionProgressBar.SetProgress(0.5f);
    }
}
