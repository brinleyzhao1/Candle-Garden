using System;
using Core;
using Inventory;
using UI;
using UnityEngine;

namespace Inventories
{
  /// <summary>
  /// Provides storage for the player inventory. A configurable number of
  /// slots are available.
  ///
  /// This component should be placed on the GameObject tagged "Player".
  /// </summary>
  public class Inventory : MonoBehaviour
  {
    // CONFIG DATA
    [Tooltip("Allowed size")] [SerializeField]
    int inventorySize = 4;

    // public CategoryEnum category;

    // STATE, the actual inventory
    InventorySlot[] _slots;

    public struct InventorySlot
    {
      public InventoryItem item;
      public int amount;
    }

    /// <summary>
    /// Broadcasts when the items in the slots are added/removed.
    /// </summary>
    public event Action InventoryUpdated;

    private void Awake()
    {
      _slots = new InventorySlot[inventorySize];
    }

    private void Start()
    {
      AddToFirstEmptySlot(GameAssets.LighterObject, 1);
      AddToFirstEmptySlot(GameAssets.ShovelObject, 1);
      AddToFirstEmptySlot(GameAssets.SeedObject, 2);
    }


    #region Functions Related to Inventory

    /// <summary>
    /// Convenience for getting the player's inventory.
    /// </summary>
    // public static Inventory GetPlayerInventory()
    // {
    //   var player = GameObject.FindWithTag("Inventory");
    //   return player.GetComponent<Inventory>();
    // }

    /// <summary>
    /// Could this item fit anywhere in the inventory?
    /// </summary>
    public bool HasSpaceFor(InventoryItem item)
    {
      return FindSlot(item) >= 0;
    }

    /// <summary>
    /// How many slots are in the inventory?
    /// </summary>
    public int GetSize()
    {
      return _slots.Length;
    }

    /// <summary>
    /// Attempt to add the items to the first available slot.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="number">The number to add.</param>
    /// <returns>Whether or not the item could be added.</returns>
    public bool AddToFirstEmptySlot(InventoryItem item, int number)
    {
      int i = FindSlot(item);

      if (i < 0)
      {
        return false;
      }

      _slots[i].item = item;
      _slots[i].amount += number;
      InventoryUpdated?.Invoke();

      return true;
    }

    /// <summary>
    /// Is there an instance of the item in the inventory?
    /// </summary>
    public int HasItem(InventoryItem item)
    {
      for (int i = 0; i < _slots.Length; i++)
      {
        if (object.ReferenceEquals(_slots[i].item, item))
        {
          return i;
        }
      }

      return -1;
    }

    /// <summary>
    /// Return the item category in the given slot.
    /// </summary>
    public InventoryItem GetItemInSlot(int slot)
    {
      return _slots[slot].item;
    }

    /// <summary>
    /// Get the number of items in the given slot.
    /// </summary>
    public int GetNumberInSlot(int slot)
    {
      return _slots[slot].amount;
    }

    /// <summary>
    /// Remove a number of items from the given slot. Will never remove more
    /// that there are.
    /// </summary>
    public void RemoveFromSlot(int slot, int number)
    {
      _slots[slot].amount -= number;
      if (_slots[slot].amount <= 0)
      {
        _slots[slot].amount = 0;
        _slots[slot].item = null;

        FindObjectOfType<InventoryUi>().slotCircled = -1;
      }

      if (InventoryUpdated != null)
      {
        InventoryUpdated();
      }



      // InventoryUi
    }

    /// <summary>
    /// Will add an item to the given slot if possible. If there is already
    /// a stack of this category, it will add to the existing stack. Otherwise,
    /// it will be added to the first empty slot.
    /// </summary>
    /// <param name="slot">The slot to attempt to add to.</param>
    /// <param name="item">The item category to add.</param>
    /// <param name="number">The number of items to add.</param>
    /// <returns>True if the item was added anywhere in the inventory.</returns>
    public bool AddItemToSlot(int slot, InventoryItem item, int number)
    {
      if (_slots[slot].item != null)
      {
        return AddToFirstEmptySlot(item, number);
        ;
      }

      var i = FindStack(item);
      if (i >= 0)
      {
        slot = i;
      }

      _slots[slot].item = item;
      _slots[slot].amount += number;
      if (InventoryUpdated != null)
      {
        InventoryUpdated();
      }

      return true;
    }

    // PRIVATE


    /// <summary>
    /// Find a slot that can accomodate the given item.
    /// </summary>
    /// <returns>-1 if no slot is found.</returns>
    private int FindSlot(InventoryItem item)
    {
      int i = FindStack(item);
      if (i < 0)
      {
        i = FindEmptySlot();
      }

      return i;
    }

    /// <summary>
    /// Find an empty slot.
    /// </summary>
    /// <returns>-1 if all slots are full.</returns>
    private int FindEmptySlot()
    {
      for (int i = 0; i < _slots.Length; i++)
      {
        if (_slots[i].item == null)
        {
          return i;
        }
      }

      return -1;
    }

    /// <summary>
    /// Find an existing stack of this item category.
    /// </summary>
    /// <returns>-1 if no stack exists or if the item is not stackable.</returns>
    private int FindStack(InventoryItem item)
    {
      if (!item.IsStackable())
      {
        return -1;
      }

      for (int i = 0; i < _slots.Length; i++)
      {
        if (object.ReferenceEquals(_slots[i].item, item))
        {
          return i;
        }
      }

      return -1;
    }

    #endregion
  }
}
