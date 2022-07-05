using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Core;
using Unity.Mathematics;
using UnityEngine;

public class UnlitCandle : MonoBehaviour
{
  public int growTime = 30;
  public int versionNum;

  public CandleState state;
  [SerializeField] private AudioClip LighterSound;

  public Block parentBlock;

  public enum CandleState
  {
    GrowingUp,
    Ready
  }


  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(1))
    {
      if (state != CandleState.Ready)
      {
        GameAssets.Feedback.ShowCannotHarvest();
        return;
      }

      float distanceFromPlayer = Vector3.Distance(GameAssets.Player.transform.position, transform.position);
      if (distanceFromPlayer > 4)
      {
        GameAssets.Feedback.ShowTooFarText();
        return; //too far
      }

      if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Lighter)
      {
        LightCandle();
      }
      else if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Harvest)
      {
        HarvestCandle();
      }
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    // _second += Time.deltaTime * timeScale / 2;
    if (state == CandleState.GrowingUp)
    {
      StartCoroutine(GrowUp());
    }
  }


  //private -----
  private void LightCandle()
  {
    GameAssets.SFX.PlayOneShot(LighterSound);

    GameObject newCandle = null;
    if (versionNum == 1)
    {
      newCandle = Instantiate(GameAssets.LightedCandle01, transform.position, Quaternion.identity);
    }
    else if (versionNum == 2)
    {
      newCandle = Instantiate(GameAssets.LightedCandle02, transform.position, Quaternion.identity);
    }


    newCandle.transform.parent = transform.parent;
    newCandle.GetComponent<LightedCandle>().parentBlock = parentBlock;
    Destroy(gameObject);
  }

  private void HarvestCandle()
  {
    GameAssets.SFX.PlayOneShot(GameAssets.HarvestSFX);
    // GameAssets.Player.candleStock += 1;

    if (versionNum == 1)
    {
      // GameAssets.ExperienceSystem.CountExperienceOnAction("harvest candle 01");
      GameAssets.inventory.AddToFirstEmptySlot(GameAssets.MatureCandle01, 1);
      // newCandle = Instantiate(GameAssets.LightedCandle01, transform.position, Quaternion.identity);
    }
    else if (versionNum == 2)
    {
      // GameAssets.ExperienceSystem.CountExperienceOnAction("harvest candle 02");
      GameAssets.inventory.AddToFirstEmptySlot(GameAssets.MatureCandle02, 1);
      // newCandle = Instantiate(GameAssets.LightedCandle02, transform.position, Quaternion.identity);
    }


    parentBlock.isEmpty = true;

    Destroy(gameObject);
  }


  private IEnumerator GrowUp()
  {
    state = CandleState.GrowingUp;

    float timePassed = 0.1f;
    while (timePassed < growTime)
    {
      int fullGrownHeight = 5;
      if (versionNum == 1)
      {
        fullGrownHeight = 15;
      }
      else if (versionNum == 2)
      {
        fullGrownHeight = 6;
      }

      var localScale = transform.localScale;
      localScale = new Vector3(localScale.x, fullGrownHeight * (timePassed / growTime), localScale.z);
      transform.localScale = localScale;
      yield return new WaitForSeconds(0.2f);
      timePassed += 0.2f;
    }

    //fully grown
    parentBlock.InstantiateGrownCandle(this.gameObject);

  }

}
