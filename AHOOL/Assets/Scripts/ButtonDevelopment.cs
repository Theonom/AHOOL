using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDevelopment : MonoBehaviour
{
   public void Prev()
    {
        SceneManager.LoadScene("More Game");
    }

   public void Close()
    {
        SceneManager.LoadScene("Menu");
    }

   public void ProfilTheo()
    {
        SceneManager.LoadScene("Profil Theo");
    }

   public void ProfilAi()
    {
        SceneManager.LoadScene("Profil Ai");
    }

   public void ProfilSiska()
    {
        SceneManager.LoadScene("Profil Siska");
    }
}
