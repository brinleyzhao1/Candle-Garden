using Core;
using UnityEngine;


namespace UI
{
  /// <summary>
  /// Responsible for the UI side of inventory.
  /// should sit on "Inventory (Slots Organizer)"
  ///
  /// </summary>
  public class InventoryUi : MonoBehaviour
  {
    // CONFIG DATA
    [SerializeField] protected InventorySlotUi inventorySlotPrefab = null;
    // public CategoryEnum categoryEnum;

    // CACHE
    private Inventories.Inventory thisInventory;


    private void Start()
    {
      // thisInventory = GameAssets.inventory;//dont know why this grabs null
      thisInventory = FindObjectOfType<Inventories.Inventory>();

      thisInventory.InventoryUpdated += Redraw;

      Redraw();
    }

    public void HideAllCircles()
    {
      foreach (Transform child in transform)
      {
        child.GetComponent<InventorySlotUi>().HideHighlight();
      }
    }


    #region Private

    private void Redraw()
    {
      // print(0);
      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }


      for (int i = 0; i < thisInventory.GetSize(); i++)
      {
        var itemUi = Instantiate(inventorySlotPrefab, transform);
        itemUi.Setup(thisInventory, i);
      }
    }

    #endregion
  }
}
