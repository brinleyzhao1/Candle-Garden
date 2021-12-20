using Inventory;
using UI.Dragging;
using UnityEngine;


namespace UI
{
  /// <summary>
  /// should sit on the prefab "Inventory Slot"
  /// </summary>
  public class InventorySlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
  {
    [SerializeField] InventoryItemIcon iconInChild = null; // own child


    // STATE
    public int index;
    InventoryItem _item;
    Inventories.Inventory inventory;


    public void Setup(Inventories.Inventory inventory, int index)
    {
      this.inventory = inventory;
      this.index = index;
      iconInChild.SetItem(inventory.GetItemInSlot(index), inventory.GetNumberInSlot(index));
    }

    public int MaxAcceptable(InventoryItem item)
    {
      if (inventory.HasSpaceFor(item))
      {
        return int.MaxValue;
      }

      return 0;
    }

    public void AddItems(InventoryItem item, int number)
    {
      inventory.AddItemToSlot(index, item, number);
    }

    public InventoryItem GetItem()
    {
      return inventory.GetItemInSlot(index);
    }

    public int GetIndex()
    {
      return index;
    }

    public int GetNumber()
    {
      return inventory.GetNumberInSlot(index);
    }

    public void RemoveItems(int number)
    {
      inventory.RemoveFromSlot(index, number);
    }


  }
}
