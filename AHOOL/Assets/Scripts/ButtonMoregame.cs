using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMoregame : MonoBehaviour
{
   public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }

   public void AboutGame()
    {
        SceneManager.LoadScene("About Game");
    }

   public void Development()
    {
        SceneManager.LoadScene("Development");
    }

   public void Prev()
    {
        SceneManager.LoadScene("Menu");
    }
}
