using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    public float jumpForce = 20f;

    private Rigidbody2D body2D;
    private BoxCollider2D box2D;
    private bool isGrounded;

    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        if (body2D == null)
        {
            body2D = gameObject.AddComponent<Rigidbody2D>();
            body2D.gravityScale = 3f;
            body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        box2D = GetComponent<BoxCollider2D>();
        if (box2D == null)
        {
            box2D = gameObject.AddComponent<BoxCollider2D>();
            box2D.size = new Vector2(1f, 1f);
        }
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if (body2D == null) return;
        Vector2 velocity = body2D.linearVelocity;
        velocity.x = inputX * moveSpeed;
        body2D.linearVelocity = velocity;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body2D.linearVelocity = new Vector2(body2D.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckGround(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckGround(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void CheckGround(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            // 간단한 접지 판정: 위쪽 접촉이 있으면 접지
            foreach (var contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    return;
                }
            }
        }
    }
}
