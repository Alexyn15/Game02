using UnityEngine;
using TMPro;
public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
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

    }
}
