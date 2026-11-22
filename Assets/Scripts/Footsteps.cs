using System;
using System.Collections;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepsSFX;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayFootSteps());
    }

   IEnumerator PlayFootSteps()
    {
        while(true)
        {
            if(rigidbody.linearVelocity.magnitude > 0.0f)
            {
                int idx = UnityEngine.Random.Range(0, footstepsSFX.Length);
                AudioManager.instance.PlaySFX(footstepsSFX[idx]);
            }

            yield return new WaitForSeconds(0.35f);
        }
    }
}
