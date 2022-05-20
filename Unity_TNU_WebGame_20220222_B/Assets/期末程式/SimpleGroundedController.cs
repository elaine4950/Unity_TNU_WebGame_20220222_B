using System.Collections.Generic;
using UnityEngine;

public class SimpleGroundedController : MonoBehaviour
{
    public float JumpImpulse = 7f;
    public float SideSpeed = 2f;

    public ContactFilter2D ContactFilter;

    private Rigidbody2D m_Rigidbody;
    private bool m_ShouldJump;
    private float m_SideSpeed;
    private string parameteRun = "開關跑步";
    private Animator ani;
    private float h;
    

    // We can check to see if there are any contacts given our contact filter
    // which can be set to a specific layer and normal angle.
    public bool IsGrounded => m_Rigidbody.IsTouching(ContactFilter);

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Set jump/
        if (Input.GetKeyDown(KeyCode.Space))
            m_ShouldJump = true;

        // Set movement.
        m_SideSpeed = (Input.GetKey(KeyCode.A) ? -SideSpeed : 0f) + (Input.GetKey(KeyCode.D) ? SideSpeed : 0f);
        ani.SetBool(parameteRun, h != 0 );
        h = Input.GetAxis("Horizontal");
        transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);
    }

    void FixedUpdate()
    {
        // Handle jump.
        // NOTE: If instructed to jump, we'll check if we're grounded.
        if (m_ShouldJump && IsGrounded)
            m_Rigidbody.AddForce(Vector2.up * JumpImpulse, ForceMode2D.Impulse);

        // Set sideways velocity.
        m_Rigidbody.velocity = new Vector2(m_SideSpeed, m_Rigidbody.velocity.y);

        // Reset movement.
        m_ShouldJump = false;
        m_SideSpeed = 0f;
    }
}
