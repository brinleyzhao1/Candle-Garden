
using Core;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  /// <summary>
  /// to be put on the right section Ui under shop panel
  /// in charge of displaying detailed information of the item chosen from the left
  /// as well as buying
  /// </summary>
  public class BuySectionUi : MonoBehaviour
  {
    [Header("children")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private TextMeshProUGUI priceText;

    private InventoryItem _thisItem;


    /// <summary>
    /// when a shop entry on the left is selected, update displayed information on the right
    /// </summary>
    /// <param name="item"></param>
    public void SetDisplayedItem(InventoryItem item)
    {
      _thisItem = item;

      titleText.text = item.GetDisplayName();
      iconImage.sprite = item.GetIcon();
      descriptionText.text = item.GetDescription();
      priceText.text = item.GetPrice().ToString();

      //check if player has enough money
      if (GameAssets.money.GetMoneyHave() >= _thisItem.GetPrice())
      {
        buyButton.GetComponent<Image>().color=Color.white;
        buyButton.GetComponent<Button>().interactable = true;
      }
      else //if not have enough money
      {
        buyButton.GetComponent<Image>().color=Color.gray;
        buyButton.GetComponent<Button>().interactable = false;
      }
    }

    public void ButtonBuy()
    {
      //todo: put in corresponding inventory depending on the type of the item

      GameAssets.seedsInventory.AddToFirstEmptySlot(_thisItem, 1);
      GameAssets.money.AddOrMinusMoney(-_thisItem.GetPrice());
    }


  }
}
