using Core;
using Inventories;
using Inventory;
using TMPro;
using UI.Dragging;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace UI
{
  public class ShopItemEntryUi : MonoBehaviour, IItemHolder
  {
    private InventoryItem _thisItem;

    [Header("from children")] [SerializeField]
    private Image entryImage;
    // [SerializeField] private TMP_Text entryNameText;
    // [SerializeField] private TMP_Text entryPriceText;


    public void SetUp(InventoryItem item)
    {
      entryImage.sprite = item.GetIcon();
      // entryNameText.text = item.GetDisplayName();
      // entryPriceText.text = item.GetBuyInPrice().ToString();

      _thisItem = item;
    }

    /// <summary>
    /// to be called when the button is selected
    /// </summary>
    public void BtnSelect()
    {
      GameAssets.buyCart.gameObject.SetActive(true);
      GameAssets.buyCart.SetDisplayedItem(_thisItem, 100);//sellindex wouldnt matter here
    }


    public InventoryItem GetItem()
    {
      return _thisItem;
    }

    public int GetIndex()
    {
      return 0; //not needed, just place holder
    }
  }
}
