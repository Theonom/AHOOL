using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
   public void StartToPlay()
    {
        SceneManager.LoadScene("Level 1");
    }
    
   public void MoreGame()
    {
        SceneManager.LoadScene("More Game");
    }

   public void Credits()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Exit()
    {
        Debug.Log("Quit The Game");
        Application.Quit();
    }
}
