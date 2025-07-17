using UnityEngine;
using TMPro;
public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth PlayerHealth;
    private GameManager gameManager;
    private Menu Menu;

    private void Awake()
    {
        PlayerHealth = FindAnyObjectByType<PlayerHealth>();
        gameManager = FindAnyObjectByType<GameManager>();
        Menu = FindAnyObjectByType<Menu>();

      
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(5);
            FindObjectOfType<SoundManager>().PlayCollectSound();
          
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("quai kia chay di");
        }
        


      if (collision.CompareTag("Trap"))
        {
            Debug.Log("Player hit a trap!");
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)   
            {
                playerHealth.TakeDamage(1); // Giảm 1 HP khi va chạm với bẫy
            }
            else
            {
                Debug.LogWarning("lỗi không tìm thấy PlayerHealth component!");
            }
        }
        if (collision.CompareTag("item"))
        {
            PlayerHealth.Heal(1); //  mỗi lần va chạm với item sẽ hồi 1 HP
            Destroy(collision.gameObject); // Xóa item sau khi lấy
        }

        if(collision.CompareTag("Finish"))
        {
            
            FindObjectOfType<Menu>().WinGame();
        }

    }

       
}
