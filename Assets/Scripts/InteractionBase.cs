using UnityEngine;
using TMPro;

public abstract class InteractionBase : MonoBehaviour
{
    public string button;
    private Canvas uiCanvas;

    void Awake()
    {
        Transform tr = transform.Find("Prompt");
        if (tr != null)
        {
            uiCanvas = tr.gameObject.GetComponent<Canvas>();

            Transform tr2 = uiCanvas.transform.Find("Text");
            if (tr2 != null)
            {
                TMP_Text text = tr2.gameObject.GetComponent<TMP_Text>();
                text.text = button;
            }

            uiCanvas.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        uiCanvas.enabled = true;
    }

    // Called when another collider exits the trigger
    void OnTriggerExit2D(Collider2D other)
    {
        uiCanvas.enabled = false;
    }

    public abstract void OnInteraction(GameObject player);
}
