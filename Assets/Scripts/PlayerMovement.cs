using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5;
    private Rigidbody2D rigidbody;
    
    //--------------------------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.linearVelocity = new Vector2(horizontal, vertical) * Speed;
    }
}
