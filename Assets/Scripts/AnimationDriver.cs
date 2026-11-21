using UnityEngine;

public class AnimationDriver : MonoBehaviour
{
    private Animator animator;
    private Transform Visuals;
    private Rigidbody2D rigidbody;

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Visuals = transform.Find("Visuals");
        if (Visuals != null)
        {
            animator = Visuals.gameObject.GetComponent<Animator>();
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        float horizontal = rigidbody.linearVelocity.x;
        float vertical = rigidbody.linearVelocity.y;

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));

        if (horizontal > 0 && Visuals.localScale.x < 0
            || horizontal < 0 && Visuals.localScale.x > 0)
        {

            Visuals.localScale = new Vector3(Visuals.localScale.x * -1, Visuals.localScale.y, Visuals.localScale.z);
        }

        if (Mathf.Abs(horizontal) + Mathf.Abs(vertical) < 0.1f)
        {
            animator.SetInteger("Direction", 0);
        }
        else
        {
            if (vertical > 0)
            {
                animator.SetInteger("Direction", 2);
            }
            else if (vertical < 0)
            {
                animator.SetInteger("Direction", 0);
            }
            else if (horizontal > 0)
            {
                animator.SetInteger("Direction", 1);
            }
            else if (horizontal < 0)
            {
                animator.SetInteger("Direction", 3);
            }
        }
    }
}
