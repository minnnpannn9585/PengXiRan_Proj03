using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动参数")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        // 左右移动
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // 检测是否在地面
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // 检测与敌人碰撞
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            // 判断是否从上方踩中敌人
            float heightDiff = transform.position.y - col.transform.position.y;
            if (heightDiff > 0.5f)
            {
                BattleSystem.Instance.OnPlayerWin();
            }
            else
            {
                BattleSystem.Instance.OnPlayerLose();
            }
        }
    }

    // 重置玩家位置
    public void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
    }
}