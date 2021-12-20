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
  /// </summary>
  public class ActionSlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
  {
    // CONFIG DATA
    [SerializeField] InventoryItemIcon iconInChild = null;
    [SerializeField] int index = 0;
    [SerializeField] private Color selectedColor;

    // CACHE
    ActionStore actionStore;

    // LIFECYCLE METHODS
    private void Awake()
    {
      print(0);
      actionStore = GameAssets.actionStore;
      print(1);
      actionStore.StoreUpdated += UpdateIcon;

      // print(2);
      // UpdateIcon(); //update once in the beginning
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
      throw new NotImplementedException();
    }


    public int GetNumber()
    {
      return actionStore.GetNumber(index);
    }

    public int MaxAcceptable(InventoryItem item)
    {
      return GameAssets.actionStore.MaxAcceptable(item, index);
    }

    public void RemoveItems(int number)
    {
      actionStore.RemoveItems(index, number);
    }

    private bool IsSelected()
    {
      return index == actionStore.currentIndexSelected;
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
