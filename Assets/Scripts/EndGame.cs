using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI dayText;
  private void OnEnable()
  {
    Time.timeScale = 0;

    int day = FindObjectOfType<TimeManager>().GetCurrentDay();
    dayText.text = day + " days";
  }

  public void BtnReloadScene()
  {
    SceneManager.LoadScene(1);
  }
}
