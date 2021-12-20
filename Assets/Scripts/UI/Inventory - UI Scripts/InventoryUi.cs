using Core;
using Inventory;
using UnityEngine;
using Inventories;

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
    public CategoryEnum categoryEnum;

    // CACHE
    private Inventories.Inventory _thisInventory;


    private void Awake()
    {

      _thisInventory = GetCorrespondingInventory();
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

    private Inventories.Inventory GetCorrespondingInventory()
    {
      if (categoryEnum == CategoryEnum.Seed)
      {
        return GameAssets.seedsInventory;
      }

      if (categoryEnum == CategoryEnum.Produce)
      {
        return GameAssets.produceInventory;
      }

      if (categoryEnum == CategoryEnum.Tools)
      {
        return GameAssets.toolsInventory;
      }

      Debug.LogError("cannot find the corresponding inventory.");
      return null; //error
    }


    #endregion

  }
}
