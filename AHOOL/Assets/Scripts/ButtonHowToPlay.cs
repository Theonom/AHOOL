using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHowToPlay : MonoBehaviour
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
