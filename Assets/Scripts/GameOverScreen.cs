using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Image redLight;
    public Image blueLight;

    public float rotSpeed = 10.0f;
    public float rotOffset = 18.0f;
    public float maxIntensity = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newIntensity = Mathf.Sin((Time.time * rotSpeed) +
             (0 * Mathf.Deg2Rad)) * maxIntensity;
        
        Color c = redLight.color;
        c.a = Mathf.Clamp(newIntensity, 0, maxIntensity);
        redLight.color = c;

        newIntensity = Mathf.Sin((Time.time * rotSpeed) +
             (rotOffset)) * maxIntensity;

        c = blueLight.color;
        c.a = Mathf.Clamp(newIntensity, 0, maxIntensity);
        blueLight.color = c;
    }
}
