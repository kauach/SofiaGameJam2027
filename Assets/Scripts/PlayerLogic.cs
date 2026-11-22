using System;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Canvas personalCanvas;
    private TMP_Text playerText;
    private float uiCountdown = 3.0f;

    public float attractionPassionGain = 0.15f;
    public float sweetSpotPassionGain = 0.30f;

    public float attractionRadius = 6.0f;
    public float sweetSpotRadius = 2.0f;

    public float Passion { get; set; } = 0.5f;

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
        tr.localScale = new Vector3(attractionRadius * 2, attractionRadius * 2, tr.localScale.z);

        tr = transform.Find("SweetSpotRadius");
        tr.localScale = new Vector3(sweetSpotRadius * 2, sweetSpotRadius * 2, tr.localScale.z);
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

    public void CheckGirlPosition(Vector3 girlPosition)
    {
        float distance = (transform.position - girlPosition).magnitude;

        if (distance < sweetSpotRadius)
            Passion += sweetSpotPassionGain * Time.deltaTime;
        else if (distance <= attractionRadius)
            Passion += attractionPassionGain * Time.deltaTime;

        Passion = Math.Min(1.0f, Math.Max(0.0f, Passion));
    }
}
