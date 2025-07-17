using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;

    [Header("Combat Settings")]
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackCooldown = 1.5f;
    private float lastAttackTime = -999f;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Transform attackPoint;

    [Header("Health")]
    [SerializeField] private int currentHealth = 3;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();

        // Nếu cooldown đã hết, kiểm tra xem có player trong vùng tấn công không
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            TryAttack();
        }
    }

    void Patrol()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;

        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !movingRight;
        }

        // Lật hướng attackPoint
        if (attackPoint != null)
        {
            Vector3 localPos = attackPoint.localPosition;
            localPos.x = Mathf.Abs(localPos.x) * (movingRight ? 1 : -1);
            attackPoint.localPosition = localPos;
        }
    }

    void TryAttack()
    {
        if (attackPoint == null) return;

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, targetLayer);
        foreach (Collider2D hit in hits)
        {
            PlayerHealth player = hit.GetComponent<PlayerHealth>();
            if (player != null)
            {
                lastAttackTime = Time.time;
                animator.SetTrigger("Attack");
                break;
            }
        }
    }

    // Gọi từ Animation Event
    public void DealDamageToPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, targetLayer);
        foreach (Collider2D hit in hits)
        {
            PlayerHealth player = hit.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} bị trúng {damage} sát thương!");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Vẽ vùng tấn công ra Scene View để debug
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
