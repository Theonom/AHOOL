using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonProfil : MonoBehaviour
{
    public void Prev()
    {
        SceneManager.LoadScene("Development");
    }

    public void Close()
    {
        SceneManager.LoadScene("Menu");
    }
}
