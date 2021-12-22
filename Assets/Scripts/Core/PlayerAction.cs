using System;
using Core;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
  public ActionMode currentActionMode = ActionMode.Harvest;

  public int seedStock;
  public int candleStock; //grown candles harvested

  //UI effect
  [Header("UI")] [SerializeField] private GameObject lighterCircle;
  [SerializeField] private GameObject stockCircle;
  [SerializeField] private GameObject tutorialPanel;

  public enum ActionMode
  {
    Seeding,
    Lighter,
    Harvest,
    Placing,
    Neutral
  }


  private void Start()
  {
    GameAssets.CandleStockNumTxt.text = candleStock.ToString();
    GameAssets.SeedStockNumTxt.text = GameAssets.Player.seedStock.ToString();
    tutorialPanel.SetActive(true);
  }

  public void ChangeToPlantingMode()
  {
    currentActionMode = ActionMode.Seeding;
  }

  public void ChangeLighterMode()
  {
    if (currentActionMode == ActionMode.Lighter)
    {
      currentActionMode = ActionMode.Neutral;
      lighterCircle.SetActive(false);
    }
    else
    {
      currentActionMode = ActionMode.Lighter;
      lighterCircle.SetActive(true);
      stockCircle.SetActive(false);
    }
  }

  public void ChangePlacingMode()
  {
    if (currentActionMode == ActionMode.Placing)
    {
      currentActionMode = ActionMode.Neutral;
      stockCircle.SetActive(false);
    }
    else
    {
      currentActionMode = ActionMode.Placing;
      stockCircle.SetActive(true);
      lighterCircle.SetActive(false);
    }
  }
}
