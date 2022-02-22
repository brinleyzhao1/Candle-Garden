using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
  public class MainMenu : MonoBehaviour
  {
    public void BtnStart()
    {
      SceneManager.LoadScene(1);
      // SceneManager.LoadScene("Game");
    }

    // public void BtnPlaySFX()
    // {
    //
    // }
  }
}
