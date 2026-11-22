using UnityEngine;

public class ProgressBarLogic : MonoBehaviour
{
    private RectTransform progress;
    private float originalProgress;
    public bool horizontal = true;

    void Awake()
    {
        Transform tr = transform.Find("Progress");
        if (tr != null)
        {
            progress = tr.gameObject.GetComponent<RectTransform>();
            if (horizontal)
                originalProgress = (progress.sizeDelta.x);
            else
                originalProgress = (progress.sizeDelta.y);
        }
    }

    public void SetProgress(float value)
    {
        if(horizontal)
            progress.sizeDelta = new Vector2(value * originalProgress, progress.sizeDelta.y);
        else
            progress.sizeDelta = new Vector2(progress.sizeDelta.x, value * originalProgress);
    }
}
