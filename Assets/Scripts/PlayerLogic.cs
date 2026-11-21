using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    private Canvas uiCanvas;
    private TMP_Text Text;
    private float uiCountdown = 3.0f;

    void Awake()
    {
        Transform tr = transform.Find("UI");
        if (tr != null)
        {
            uiCanvas = tr.gameObject.GetComponent<Canvas>();

            Transform tr2 = uiCanvas.transform.Find("Text");
            if (tr2 != null)
            {
                Text = tr2.gameObject.GetComponent<TMP_Text>();
                Text.text = gameObject.name;
            }

            uiCanvas.enabled = false;
        }
    }

    public void Update()
    {
        if (uiCanvas.enabled)
        {
            uiCountdown -= Time.deltaTime;
            if (uiCountdown < 0.0f)
                uiCanvas.enabled = false;
        }
    }

    public void TestInteraction(string text)
    {
        Text.text = text;
        uiCanvas.enabled = true;
        uiCountdown = 3.0f;
    }
}
