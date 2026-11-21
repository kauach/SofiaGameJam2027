using UnityEngine;

public class ProgressBarLogic : MonoBehaviour
{
    private RectTransform progress;
    private float originalWidth;

    void Awake()
    {
        Transform tr = transform.Find("Progress");
        if (tr != null)
        {
            progress = tr.gameObject.GetComponent<RectTransform>();
            originalWidth = (progress.sizeDelta.x);
        }
    }

    public void SetProgress(float value)
    {
        progress.sizeDelta = new Vector2(value * originalWidth, progress.sizeDelta.y);
    }
}
