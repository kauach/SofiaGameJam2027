using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5;
    private Rigidbody2D rigidbody;
    private Animator animator;

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.linearVelocity = new Vector2(horizontal, vertical) * Speed;

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));

        if (horizontal > 0 && transform.localScale.x < 0 
            || horizontal < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
