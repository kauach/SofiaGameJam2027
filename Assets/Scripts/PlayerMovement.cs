using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Transform Visuals;

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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.linearVelocity = new Vector2(horizontal, vertical) * Speed;

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));

        if (horizontal > 0 && Visuals.localScale.x < 0 
            || horizontal < 0 && Visuals.localScale.x > 0)
        {

            Visuals.localScale = new Vector3(Visuals.localScale.x * -1, Visuals.localScale.y, Visuals.localScale.z);
        }
    }
}
