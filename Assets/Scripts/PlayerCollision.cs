using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<SoundManager>().PlayCollectSound(); 
            gameManager.AddScore(1);
          
        } else if(collision.CompareTag("Enemy")){
            Debug.Log("quai kia chay di");
        }

    }
}
