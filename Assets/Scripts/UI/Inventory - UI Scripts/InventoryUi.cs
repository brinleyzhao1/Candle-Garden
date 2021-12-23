
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
    private Inventories.Inventory _thisInventory;


    private void Awake()
    {

      _thisInventory = GetComponent<Inventories.Inventory>();
      _thisInventory.InventoryUpdated += Redraw;

      Redraw();
    }


    #region Private

    private void Redraw()
    {
      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }

      for (int i = 0; i < _thisInventory.GetSize(); i++)
      {
        var itemUi = Instantiate(inventorySlotPrefab, transform);
        itemUi.Setup(_thisInventory, i);
      }
    }



    #endregion

  }
}
