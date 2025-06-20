using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
  public string NameLevel;
  public void LoadLevel()
  {
    SceneManager.LoadScene(NameLevel);
   FindObjectOfType<SoundManager>().PlayWinSound();
  } 
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.CompareTag("Player")){
     
      LoadLevel();
    }

  }
}
