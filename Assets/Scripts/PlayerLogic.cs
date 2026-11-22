using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    private Canvas personalCanvas;
    private TMP_Text playerText;
    private float uiCountdown = 3.0f;
    
    public float attractionRadius = 6.0f;
    public float sweetSpotRadius = 2.0f;

    public float Passion { get; set; } = 1.0f;

    void Awake()
    {
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

        tr = transform.Find("AttractionRadius");
        tr.scale.y = tr.scale.x = attractionRadius;

        tr = transform.Find("SweetSpotRadius");
        tr.scale.y = tr.scale.x = sweetSpotRadius;
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
    }
}
