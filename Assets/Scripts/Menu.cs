using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public GameObject panel;
    public GameObject WinGameUi; 


     public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
     public void QuitGame()
    {
        Application.Quit();
    }
    
     public void showpanel()
    {
      panel.SetActive(true);
    }
    
     public void hidepanel()
    {
        panel.SetActive(false);
    }

 public void loadLevel1()
 {
    SceneManager.LoadScene("Scene1");
 }
 public void loadLevel2()
 {
    SceneManager.LoadScene("Scene2");
 }
 public void loadLevel3()
 {
    SceneManager.LoadScene("Scene3");
 }
  public void loadLevel4()
 {
    SceneManager.LoadScene("Scene4");
 }

        public void btnResetGame()
        {
            FindObjectOfType<GameManager>().ResetGame();
        }

         public void WinGame()
        {   

            WinGameUi.SetActive(true); // Hiển thị UI Win Game
            

        }


        public void exittoMainMenu()
        {
            SceneManager.LoadScene("Menu");
        }


       public void nextLevel()
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
}
