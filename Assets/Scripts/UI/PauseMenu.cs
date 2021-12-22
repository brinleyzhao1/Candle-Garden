
using System;
using UnityEngine;

namespace UI
{
  public class PauseMenu : MonoBehaviour
  {
    [SerializeField] private GameObject tutorialPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

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
      BtnClose();
    }

    public void BtnQuit()
    {
      Application.Quit();
    }
  }
}
