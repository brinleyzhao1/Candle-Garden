using System;
using UnityEngine;

namespace UI
{
  public class PauseMenu : MonoBehaviour
  {
    [SerializeField] private GameObject tutorialPanel;


    private void OnEnable()
    {
      Time.timeScale = 0;
    }

    public void BtnClose()
    {
      Time.timeScale = 1;
      gameObject.SetActive(false);
    }

    public void BtnTutorial()
    {
      tutorialPanel.SetActive(true);
      gameObject.SetActive(false);
    }

    public void BtnQuit()
    {
      Application.Quit();
    }
  }
}
