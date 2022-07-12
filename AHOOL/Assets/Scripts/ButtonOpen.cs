using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOpen : MonoBehaviour
{
  public void StartToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
