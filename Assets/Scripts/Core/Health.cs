using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
  [SerializeField] private int totalHealth = 100;
  private int currentHealth;
  [SerializeField] private int damagePerSec = 5;
  [SerializeField] private int intervalSecondsDamage = 1;

  private bool damageCoroutineRunning = false;
  private Image healthBar;

  private void Start()
  {
     healthBar = GetComponent<Image>();
     currentHealth = totalHealth;
    StartCoroutine(CheckIfPlayerInDanger());
  }

  private IEnumerator CheckIfPlayerInDanger()
  {
    yield return new WaitForSecondsRealtime(2); //initial buffer

    while (true)
    {
      if (IsPlayerSafe())
      {
        // print("player safe");
        // StopCoroutine(DamageIfUnsafe());
        damageCoroutineRunning = false;
      }
      else //in danger
      {
        // print("player in danger");
        if (damageCoroutineRunning == false)
        {
          StartCoroutine(DamageIfUnsafe());

        }
      }

      yield return new WaitForSecondsRealtime(1); //check again in one second
    }

  }

  private bool IsPlayerSafe()
  {
    //get all candles that are lighted
    var lightedCandles = FindObjectsOfType<LightedCandle>();
    //if player is not in close proximity to any
    foreach (var candle in lightedCandles)
    {
      var distance = Vector3.Distance(candle.transform.position, GameAssets.Player.transform.position);
      // print(distance);
      if (distance < 4f)
      {
        return true; //safe
      }
    }

    return false;
  }

  private IEnumerator DamageIfUnsafe()
  {
    damageCoroutineRunning = true;
    while (damageCoroutineRunning == true)
    {
      currentHealth -= damagePerSec;

      GameAssets.SFX.PlayOneShot(GameAssets.LoseHealthSFX);
      UpdateUi();

      if (currentHealth <= 0)
      {
        Death();
        damageCoroutineRunning = false;
        yield break;
      }

      yield return new WaitForSeconds(intervalSecondsDamage);
    }
  }

  private void Death()
  {
    print("game over");
  }

  private void UpdateUi()
  {
    healthBar.fillAmount = (float) currentHealth / totalHealth;
  }
}
