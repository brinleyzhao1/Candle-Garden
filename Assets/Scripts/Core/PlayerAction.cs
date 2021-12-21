
using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
  public ActionMode currentActionMode = ActionMode.Harvest;

  public int candleStock; //grown candles harvested

  public enum ActionMode
  {
    Planting,
    Lighter,
    Harvest
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
  public void ChangeToLighterMode()
  {
    currentActionMode = ActionMode.Lighter;
  }


}
