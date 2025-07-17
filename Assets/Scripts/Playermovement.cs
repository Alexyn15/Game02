using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    private float targetVelocity;
    private float velocityXSmooth;

    public Transform attackPoint;
    public float attackRadius = 1f;
    public LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimation();

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // dùng GetAxisRaw để lấy giá trị -1/0/1
        targetVelocity = moveInput * moveSpeed;

        // Smooth chuyển động trên trục X
        float smoothedVelocityX = Mathf.SmoothDamp(rb.linearVelocity.x, targetVelocity, ref velocityXSmooth, 1f / acceleration);
        rb.linearVelocity = new Vector2(smoothedVelocityX, rb.linearVelocity.y);

        // Lật hướng
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            FindObjectOfType<SoundManager>().PlayJumpSound();
        }
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }

   
   public void Attack()
{
    Collider2D[] collInfos = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, targetLayer);
    Debug.Log("Attack event, number of hits: " + collInfos.Length);
    foreach (Collider2D col in collInfos)
    {
        Debug.Log("Hit: " + col.name);
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("Enemy hit! Gây damage");
            enemy.TakeDamage(1);
        }
    }
}

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}