using Core;
using UnityEngine;

namespace UI
{
  public class UiManager : MonoBehaviour
  {

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject shopMenu;
    private void Update()
    {
      if (Input.GetKey(KeyCode.Escape))
      {

        if (shopMenu.activeSelf)
        {
          shopMenu.SetActive(false);
        }
        else if (pauseMenu.activeSelf)
        {
          pauseMenu.SetActive(false);
        }
        else
        {
          pauseMenu.SetActive(true);
        }

        GameAssets.SFX.PlayOneShot(GameAssets.UiPaperSFX);


      }
    }
  }
}
