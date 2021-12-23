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
    [Header("children")] [SerializeField] private TextMeshProUGUI itemNameText;

    [SerializeField] private Image iconImage;

    // [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI amountText;

    private InventoryItem _thisItem;

    private int currentTransactionAmount = 1;
    private int currentTransactionMoney;


    /// <summary>
    /// when a shop entry on the left is selected, update displayed information on the right
    /// </summary>
    /// <param name="item"></param>
    public void SetDisplayedItem(InventoryItem item)
    {
      _thisItem = item;

      itemNameText.text = item.GetDisplayName();
      iconImage.sprite = item.GetIcon();
      // descriptionText.text = item.GetDescription();

      UpdateTransactionMoney();
      amountText.text = currentTransactionAmount.ToString();

      //check if player has enough money
      if (GameAssets.money.GetMoneyHave() >= _thisItem.GetPrice())
      {
        buyButton.GetComponent<Image>().color = Color.white;
        buyButton.GetComponent<Button>().interactable = true;
      }
      else //if not have enough money
      {
        buyButton.GetComponent<Image>().color = Color.gray;
        buyButton.GetComponent<Button>().interactable = false;
      }
    }

    public void BtnBuy()
    {
      GameAssets.seedsInventory.AddToFirstEmptySlot(_thisItem, currentTransactionAmount);
      GameAssets.money.AddOrMinusMoney(-currentTransactionMoney);
      //todo:add to inventory
    }

    public void BtnAddOne()
    {
      currentTransactionAmount += 1;
      amountText.text = currentTransactionAmount.ToString();
      UpdateTransactionMoney();
    }


    public void BtnMinusOne()
    {
      currentTransactionAmount -= 1;
      if (currentTransactionAmount <= 0)
      {
        currentTransactionAmount = 0;
      }
      amountText.text = currentTransactionAmount.ToString();
      UpdateTransactionMoney();
    }

    private void UpdateTransactionMoney()
    {
      currentTransactionMoney = currentTransactionAmount * _thisItem.GetPrice();
      priceText.text = currentTransactionMoney.ToString();
    }
  }
}
