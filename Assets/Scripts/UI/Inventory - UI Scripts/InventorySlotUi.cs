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
    [SerializeField] private GameObject circle;
    int index = 0;
    // [SerializeField] private Color selectedColor;

    Inventories.Inventory inventory;
    private InventoryItem thisItem;



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
      thisItem = inventory.GetItemInSlot(index);
      iconInChild.SetItem(thisItem, inventory.GetNumberInSlot(index));


    }

    private void Start()
    {
      // actionStore.StoreUpdated += UpdateIcon;
    }

    public void BtnSelect()
    {


      if (thisItem.category == CategoryEnum.Seed)
      {
        GameAssets.Player.ChangeToSeedingMode();//changing mode hides all circles
        OpenCircle();
      }
      else if (thisItem.category == CategoryEnum.Candle)
      {
        GameAssets.Player.ChangeToPlacingMode();
        OpenCircle();
      }
      else if (thisItem.category == CategoryEnum.Tools)
      {
        GameAssets.Player.ChangeToLighterMode();
        OpenCircle();
      }
    }

    private void OpenCircle()
    {
      circle.gameObject.SetActive(true);
      GameAssets.SFX.PlayOneShot(GameAssets.ActionSlotSFX);
    }
    // PUBLIC

    public void AddItems(InventoryItem item, int number)
    {
      // print("add action item");
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

    public int MaxAcceptable(InventoryItem item)
    {
      return 100;
      // return GameAssets.actionStore.MaxAcceptable(item, index);
    }

    public void RemoveItems(int number)
    {
      inventory.RemoveFromSlot(index, number);
    }


    public void HideHighlight()
    {
      circle.gameObject.SetActive(false);
    }
  }
}
