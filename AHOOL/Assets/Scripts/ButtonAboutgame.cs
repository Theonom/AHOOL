using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAboutgame : MonoBehaviour
{
   public void Prev()
    {
        SceneManager.LoadScene("More Game");
    }

   public void Close()
    {
        SceneManager.LoadScene("Menu");
    }
}
