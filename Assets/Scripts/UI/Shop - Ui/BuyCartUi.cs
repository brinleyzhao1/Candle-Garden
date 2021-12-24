using System.Linq.Expressions;
using Core;
using Inventories;
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
  public class BuyCartUi : MonoBehaviour
  {
    [Header("children")] [SerializeField] private TextMeshProUGUI itemNameText;

    [SerializeField] private Image iconImage;

    // [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI amountText;

    enum Mode
    {
      Buy,
      Sell
    }

    [SerializeField] private Mode mode;

    private InventoryItem thisItem;
    private int thisPrice;

    private int currentTransactionAmount = 1;
    private int currentTransactionMoney;
    private int sellSlotIndex;

    Inventories.Inventory inventory;


    /// <summary>
    /// when a shop entry on the left is selected, update displayed information on the right
    /// </summary>
    /// <param name="item"></param>
    public void SetDisplayedItem(InventoryItem item, int sellIndex)
    {
      thisItem = item;

      itemNameText.text = item.GetDisplayName();
      iconImage.gameObject.SetActive(true);
      iconImage.sprite = item.GetIcon();
      // descriptionText.text = item.GetDescription();

      sellSlotIndex = sellIndex;
      inventory = FindObjectOfType<Inventories.Inventory>();


      //set price
      if (mode == Mode.Buy)
      {
        thisPrice = thisItem.GetBuyInPrice();
      }
      else if (mode == Mode.Sell)
      {
        thisPrice = thisItem.GetSellOutPrice();
      }
      priceText.color = Color.white;
      priceText.text = thisPrice.ToString();
      UpdateTransactionMoney();
      amountText.text = currentTransactionAmount.ToString();

      if (UpdateBuyCart()) return;
      //check if player has enough money
      // if (GameAssets.money.GetMoneyHave() >= thisItem.GetBuyInPrice())
      // {
      //   buyButton.GetComponent<Image>().color = Color.white;
      //   buyButton.GetComponent<Button>().interactable = true;
      // }
      // else //if not have enough money
      // {
      //   buyButton.GetComponent<Image>().color = Color.gray;
      //   buyButton.GetComponent<Button>().interactable = false;
      // }
    }

    public void BtnBuy()
    {
      if (UpdateBuyCart()) return;
      GameAssets.Inventory.AddToFirstEmptySlot(thisItem, currentTransactionAmount);
      GameAssets.money.AddOrMinusMoney(-currentTransactionMoney);
      PlayMusicSFX();
      
      if (UpdateBuyCart()) return;
    }

    public void BtnSell()
    {
      if (UpdateSellCart()) return;
      //todo:update sell cart. if out of stock cannot sell anymore

      GameAssets.Inventory.RemoveFromSlot(sellSlotIndex, currentTransactionAmount);
      GameAssets.money.AddOrMinusMoney(+currentTransactionMoney);
      PlayMusicSFX();

      if (UpdateSellCart()) return;

    }

    private bool UpdateBuyCart()
    {
      if (GameAssets.money.GetMoneyHave() < thisItem.GetBuyInPrice())
      {
        priceText.color = Color.red;
        return true;
      }

      return false;
    }
    private bool UpdateSellCart()
    {
      int stockLeft = inventory.GetNumberInSlot(sellSlotIndex);
      if (stockLeft < currentTransactionAmount)
      {
        priceText.color = Color.red;
        // iconImage.gameObject.SetActive(false);
        return true;
      }

      return false;
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
      currentTransactionMoney = currentTransactionAmount * thisPrice;
      priceText.text = currentTransactionMoney.ToString();
    }

    private void PlayMusicSFX()
    {
      GameAssets.SFX.PlayOneShot(GameAssets.MoneySFX);
    }
  }
}
