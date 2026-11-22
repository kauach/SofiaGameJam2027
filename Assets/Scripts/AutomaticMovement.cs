using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class POITimer
{
    public GameObject gameObject;
    public float time;
}

public class AutomaticMovement : MonoBehaviour
{
    public float Speed = 5;
    private Rigidbody2D rigidbody;

    public POITimer[] POIList;
    private int currentPOI = -1;
    private float timer = 100;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (POIList.Length > 0)
        {
            currentPOI = 0;
            UnityEngine.Debug.Log($"kurwa {POIList.Length}");
        }
    }

    void FixedUpdate()
    {
        if (currentPOI < 0)
            return;

        Transform poiTransform = POIList[currentPOI].gameObject.transform;
        Vector2 dist = poiTransform.position - transform.position;

        if (dist.magnitude < 0.2f)
        {
            rigidbody.linearVelocity = Vector2.zero;
            if (timer < POIList[currentPOI].time)
                timer += Time.deltaTime;
            else
            {
                currentPOI = (currentPOI + 1) % POIList.Length;
                timer = 0.0f;
            }
        }
        else
        {
            dist.Normalize();
            rigidbody.linearVelocity = dist * Speed;
        }

        dist.Normalize();
        GetComponent<FieldOfView>().lookDirection = dist;
    }

}
