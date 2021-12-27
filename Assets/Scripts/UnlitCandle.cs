using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class UnlitCandle : MonoBehaviour
{
  public int growTime = 30;

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
    if (Input.GetMouseButtonDown(1) && state == CandleState.Ready)
    {
      float distanceFromPlayer = Vector3.Distance(GameAssets.Player.transform.position, transform.position);
      if (distanceFromPlayer > 4)
      {
        return; //too far
      }


      if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Lighter)
      {
        LightCandle();
      }
      else
      {
        HarvestCandle();
      }
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    // _second += Time.deltaTime * timeScale / 2;
    if (state==CandleState.GrowingUp)
    {
      StartCoroutine(GrowUp());
    }

  }




  //private -----
  private void LightCandle()
  {
    GameAssets.SFX.PlayOneShot(LighterSound);

    var newCandle = Instantiate(GameAssets.LightedCandle01, transform.position, Quaternion.identity);
    newCandle.transform.parent = transform.parent;
    newCandle.GetComponent<LightedCandle>().parentBlock = parentBlock;
    Destroy(gameObject);
  }

  private void HarvestCandle()
  {
    // GameAssets.Player.candleStock += 1;
    GameAssets.inventory.AddToFirstEmptySlot(GameAssets.matureCandle, 1);
    //todo: add to first candle slot if already has candle
    // GameAssets.CandleStockNumTxt.text = GameAssets.Player.candleStock.ToString();
    Destroy(gameObject);
  }


  private IEnumerator GrowUp()
  {
    state = CandleState.GrowingUp;

    float timeLeft = 0.1f;
    while (timeLeft < growTime)
    {
      transform.localScale = new Vector3(9, 15 * (timeLeft / growTime), 9);
      yield return new WaitForSeconds(0.2f);
      timeLeft += 0.2f;
    }

    state = CandleState.Ready;
    ReadyToHarvest();
  }

  private void ReadyToHarvest()
  {
    var matureEffect = Instantiate(GameAssets.MatureEffect, transform.position, Quaternion.identity);
    matureEffect.transform.parent = transform;
    matureEffect.transform.position = matureEffect.transform.position;
  }
}
