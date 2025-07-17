using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject GameOverUi; // Thêm biến để tham chiếu đến GameOver UI
    
    void Start()
    {
      UpdateScore();
    }

    
    void Update()
    {

    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();

    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString(); 
    }

   public void GameOver()
   {

    
    Time.timeScale = 0; // Dừng thời gian trong game
    GameOverUi.SetActive(true); // Hiển thị UI Game Over
   }

   

    public void ResetGame()
    {
        
      Time.timeScale = 1; // Đặt lại thời gian về bình thường
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại scene hiện tại
    }



}
