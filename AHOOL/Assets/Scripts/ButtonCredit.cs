using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCredit : MonoBehaviour
{
   public void Prev()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Close()
    {
        SceneManager.LoadScene("Menu");
    }
}
