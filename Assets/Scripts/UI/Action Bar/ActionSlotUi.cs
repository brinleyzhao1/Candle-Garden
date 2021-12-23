using System;
using Core;
using Inventory;
using UI.Dragging;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Action_Bar
{
  /// <summary>
  /// The UI slot for the player action bar.
  /// combined actionSlotUi.cs and InventorySlotUi.cs
  /// </summary>
  public class ActionSlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
  {
    // CONFIG DATA
    [SerializeField] InventoryItemIcon iconInChild = null;
    [SerializeField] int index = 0;
    [SerializeField] private Color selectedColor;

    Inventories.Inventory inventory;

    // CACHE
    // ActionStore actionStore;


    private void Awake()
    {
      // actionStore = GameAssets.actionStore;
      // actionStore.StoreUpdated += UpdateIcon;

      // UpdateIcon(); //update once in the beginning
    }


    public void Setup(Inventories.Inventory inventory, int index)
    {
      this.inventory = inventory;
      this.index = index;
      iconInChild.SetItem(inventory.GetItemInSlot(index), inventory.GetNumberInSlot(index));
    }

    private void Start()
    {
      // actionStore.StoreUpdated += UpdateIcon;
    }

    // PUBLIC

    public void AddItems(InventoryItem item, int number)
    {
      print("add action item");
      GameAssets.actionStore.AddActionItem(item, index, number);
    }

    public InventoryItem GetItem()
    {
      return GameAssets.actionStore.GetActionItem(index);
    }

    public int GetIndex()
    {
      return index;
    }


    public int GetNumber()
    {
      return inventory.GetNumberInSlot(index);
    }

    public int MaxAcceptable(InventoryItem item)
    {
      return GameAssets.actionStore.MaxAcceptable(item, index);
    }

    public void RemoveItems(int number)
    {
      inventory.RemoveFromSlot(index, number);
    }

    private bool IsSelected()
    {
      print("not implement3ed");
      return false;
      // throw NotImplementedException;
      // return index == actionStore.currentIndexSelected;
    }

    // PRIVATE

    void UpdateIcon()
    {
      iconInChild.SetItem(GetItem(), GetNumber());

      //if is selected, highlight
      // HighlightIfSelected();
    }

    private void HighlightIfSelected()
    {
      var slotImage = GetComponent<Image>();

      if (IsSelected())
      {
        // slotImage.color = Color.green;
        slotImage.color = selectedColor;
      }
      else
      {
        slotImage.color = Color.white;
      }
    }
  }
}
