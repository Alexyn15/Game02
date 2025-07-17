using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public  TextMeshProUGUI healthText; // Sử dụng TextMeshPro để hiển thị HP
    public GameObject GameOver; // Thêm biến để tham chiếu đến GameOver panel

    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "  " + currentHealth.ToString();
    }

    void Die()
    {
        Debug.Log("Player đã chết!");
        gameObject.SetActive(false); // Ẩn nhân vật khi chết
        gameManager.GameOver(); // Gọi hàm GameOver từ GameManager
        
        

    }

}