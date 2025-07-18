using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int maxHealth = 100;

    private Animator animator;
    private float lastAttackTime;
    private int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            // Di chuyển đến player
            animator.SetBool("iswalking", true);
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);

            // Lật hướng boss nếu cần
            Vector3 scale = transform.localScale;

            if (direction.x > 0) 
            transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
            else if (direction.x < 0) 
            transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);

        }
        else
        {
            // Dừng đi, chuyển sang tấn công
            animator.SetBool("iswalking", false);

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                animator.SetTrigger("cleave");
                lastAttackTime = Time.time;
            }
        }
    }

    // Hàm nhận sát thương (gọi từ bên ngoài)
    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        animator.SetTrigger("takehit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        // Option: disable AI
        this.enabled = false;
    }
}
