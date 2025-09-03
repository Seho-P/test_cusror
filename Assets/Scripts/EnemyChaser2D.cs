using UnityEngine;

public class EnemyChaser2D : MonoBehaviour
{
    [Header("Chase Settings")]
    public Transform target;
    public float moveSpeed = 3f;
    public float stopDistance = 0.5f;

    [Header("Grounding Settings")]
    public LayerMask groundLayer;
    public float groundCheckPadding = 0.02f; // 지면 판정 여유

    private Rigidbody2D body2D;
    private BoxCollider2D box2D;
    private bool isGrounded;

    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        if (body2D == null)
        {
            body2D = gameObject.AddComponent<Rigidbody2D>();
        }
        body2D.gravityScale = 3f; // 공중에서 시작해도 착지하도록 중력 활성화
        body2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        box2D = GetComponent<BoxCollider2D>();
        if (box2D == null)
        {
            box2D = gameObject.AddComponent<BoxCollider2D>();
            box2D.isTrigger = false;
            box2D.size = new Vector2(1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        if (body2D == null || target == null) return;

        // 지면 판정
        UpdateGrounded();

        // 공중에서는 추적하지 않고 낙하만 진행 (수평 속도 0)
        if (!isGrounded)
        {
            var falling = body2D.linearVelocity;
            falling.x = 0f;
            body2D.linearVelocity = falling;
            return;
        }

        // 지면에 붙어 있을 때만 수평으로 추적 (Y 성분 유지)
        float dx = target.position.x - transform.position.x;
        float absDx = Mathf.Abs(dx);

        if (absDx > stopDistance)
        {
            float dirX = Mathf.Sign(dx);
            Vector2 v = body2D.linearVelocity;
            v.x = dirX * moveSpeed;
            body2D.linearVelocity = v;
        }
        else
        {
            Vector2 v = body2D.linearVelocity;
            v.x = 0f;
            body2D.linearVelocity = v;
        }
    }

    private void UpdateGrounded()
    {
        if (box2D == null)
        {
            isGrounded = false;
            return;
        }

        // BoxCollider2D의 하단에서 얇은 박스캐스트로 지면을 체크
        Bounds b = box2D.bounds;
        Vector2 boxCenter = new Vector2(b.center.x, b.min.y - groundCheckPadding * 0.5f);
        Vector2 boxSize = new Vector2(b.size.x * 0.9f, groundCheckPadding);
        RaycastHit2D hit = Physics2D.BoxCast(boxCenter, boxSize, 0f, Vector2.down, 0f, groundLayer);
        isGrounded = hit.collider != null;
    }
}
