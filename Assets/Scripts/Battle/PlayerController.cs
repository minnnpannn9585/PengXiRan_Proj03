using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动参数")]
    public float moveSpeed = 5f;

    [Header("动画参数")]
    [SerializeField] private Animator animator;

    [Header("角色朝向")]
    [SerializeField] private Transform visualTransform;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Vector3 visualLocalScale;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (visualTransform == null)
        {
            visualTransform = transform;
        }

        visualLocalScale = visualTransform.localScale;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        bool isRunning = Mathf.Abs(inputX) > 0.01f;
        animator.SetBool("IsRunning", isRunning);

        UpdateFacing(inputX);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void UpdateFacing(float inputX)
    {
        if (inputX > 0.01f)
        {
            visualTransform.localScale = new Vector3(
                Mathf.Abs(visualLocalScale.x),
                visualLocalScale.y,
                visualLocalScale.z);
        }
        else if (inputX < -0.01f)
        {
            visualTransform.localScale = new Vector3(
                -Mathf.Abs(visualLocalScale.x),
                visualLocalScale.y,
                visualLocalScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
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

    public void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        animator.SetBool("IsRunning", false);
    }
}