using Core;
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

    [Header("from children")]
    [SerializeField] private Image entryImage;
    // [SerializeField] private TMP_Text entryNameText;
    // [SerializeField] private TMP_Text entryPriceText;


    public void SetUp(InventoryItem item)
    {
      entryImage.sprite = item.GetIcon();
      // entryNameText.text = item.GetDisplayName();
      // entryPriceText.text = item.GetPrice().ToString();

      _thisItem = item;
    }

    /// <summary>
    /// to be called when the button is selected
    /// </summary>
    public void BtnSelect()
    {GameAssets.buySection.gameObject.SetActive(true);
      GameAssets.buySection.SetDisplayedItem(_thisItem);
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
