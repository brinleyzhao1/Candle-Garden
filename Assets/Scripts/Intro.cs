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
    if (Input.anyKey)
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
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene(2);
  }

}
