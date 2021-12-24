using Core;
using Inventories;
using Inventory;
using UI.Dragging;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
  /// <summary>
  /// should sit on the prefab "Inventory Slot"
  /// </summary>
  public class InventorySlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
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
      // print("add action item");
      inventory.AddItemToSlot(index,item,number);
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

    public int MaxAcceptable(InventoryItem item)
    {
      return 100;
      // return GameAssets.actionStore.MaxAcceptable(item, index);
    }

    public void RemoveItems(int number)
    {
      inventory.RemoveFromSlot(index, number);
    }

    // private bool IsSelected()
    // {
    //   // print("not implement3ed");
    //   return false;
    //   // throw NotImplementedException;
    //   // return index == actionStore.currentIndexSelected;
    // }

    // PRIVATE

    // void UpdateIcon()
    // {
    //   iconInChild.SetItem(GetItem(), GetNumber());
    //
    //   //if is selected, highlight
    //   // HighlightIfSelected();
    // }

    // private void HighlightIfSelected()
    // {
    //   var slotImage = GetComponent<Image>();
    //
    //   if (IsSelected())
    //   {
    //     // slotImage.color = Color.green;
    //     slotImage.color = selectedColor;
    //   }
    //   else
    //   {
    //     slotImage.color = Color.white;
    //   }
    // }
  }
}
