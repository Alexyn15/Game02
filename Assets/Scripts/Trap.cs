using UnityEngine;

public class Trap : MonoBehaviour
{
   
    void Start()
    {
        

    }

    
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
                Debug.LogWarning("PlayerHealth component not found!");
            }
        }
        
          
        
    }
}

