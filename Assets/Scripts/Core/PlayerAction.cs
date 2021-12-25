using UI;
using UnityEngine;

namespace Core
{
  public class PlayerAction : MonoBehaviour
  {
    public ActionMode currentActionMode = ActionMode.Harvest;

    public int seedStock;
    // public int candleStock; //grown candles harvested

    //UI effect
    [Header("UI")] [SerializeField] private GameObject lighterCircle;
    [SerializeField] private GameObject stockCircle;
    [SerializeField] private GameObject tutorialPanel;

    private InventoryUi inventoryUi;

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
      // GameAssets.CandleStockNumTxt.text = candleStock.ToString();
      GameAssets.SeedStockNumTxt.text = GameAssets.Player.seedStock.ToString();
      tutorialPanel.SetActive(true);
      inventoryUi = FindObjectOfType<InventoryUi>();
    }

    public void ChangeToLighterMode()
    {
      inventoryUi.HideAllCircles();
      currentActionMode = ActionMode.Lighter;
      lighterCircle.SetActive(true);
      stockCircle.SetActive(false);
    }

    public void ChangeToPlacingMode()
    {
      inventoryUi.HideAllCircles();
      currentActionMode = ActionMode.Placing;
      stockCircle.SetActive(true);
      lighterCircle.SetActive(false);
    }

    public void ChangeToSeedingMode()
    {
      currentActionMode = ActionMode.Seeding;
      inventoryUi.HideAllCircles();
    }
  }
}
