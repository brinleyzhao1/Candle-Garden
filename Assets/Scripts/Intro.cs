using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
  [SerializeField] private GameObject[] texts;
  [SerializeField]private int currentIndex = 1;

  private void Update()
  {
    if (Input.GetMouseButtonUp(0))
    {
     texts[currentIndex].SetActive(true);
     currentIndex += 1;

     if (currentIndex>=4)
     {
       StartCoroutine(NextScene());
     }
    }
  }

  IEnumerator NextScene()
  {
    yield return new WaitForSeconds(1.5f);
    SceneManager.LoadScene(2);
  }

}
