using UI;
using UnityEngine;

namespace Core
{
  public class PlayerAction : MonoBehaviour
  {
    public ActionMode currentActionMode = ActionMode.Harvest;


    // public int candleStock; //grown candles harvested

    //UI effect
    // [Header("UI")] [SerializeField] private GameObject lighterCircle;
    // [SerializeField] private GameObject stockCircle;
    [SerializeField] private GameObject tutorialPanel;

    // private InventoryUi inventoryUi;

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
      // GameAssets.SeedStockNumTxt.text = GameAssets.Player.seedStock.ToString();
      tutorialPanel.SetActive(true);
    }

    public void ChangeToLighterMode()
    {
      currentActionMode = ActionMode.Lighter;

    }

    public void ChangeToShovelMode()
    {
      // inventoryUi.HideAllCircles();
      currentActionMode = ActionMode.Harvest;

    }

    public void ChangeToPlacingMode()
    {
      currentActionMode = ActionMode.Placing;

    }

    public void ChangeToSeedingMode()
    {
      currentActionMode = ActionMode.Seeding;
    }
  }
}
