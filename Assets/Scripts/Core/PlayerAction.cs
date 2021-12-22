using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
  public ActionMode currentActionMode = ActionMode.Harvest;

  public int candleStock; //grown candles harvested

  //UI effect
  [SerializeField] private GameObject lighterCircle;

  public enum ActionMode
  {
    Planting,
    Lighter,
    Harvest,
    Neutral
  }

  // private void Update()
  // {
  //   if (Input.GetKeyUp(KeyCode.K))
  //   {
  //     ChangeToPlantingMode();
  //   }
  // }

  public void ChangeToPlantingMode()
  {
    currentActionMode = ActionMode.Planting;
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
    }
  }
}
