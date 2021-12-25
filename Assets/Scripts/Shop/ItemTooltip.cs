using Core;
using Inventories;
using Inventory;
using TMPro;
using UnityEngine;

namespace Shop
{
  /// <summary>
  /// Root of the tooltip prefab to expose properties to other classes.
  /// </summary>
  public class ItemTooltip : MonoBehaviour
  {
    // CONFIG DATA
    [SerializeField] TextMeshProUGUI titleText = null;
    [SerializeField] TextMeshProUGUI bodyText = null;

    private InventoryItem thisItem;

    private int thisIndex;
    // PUBLIC

    public void Setup(InventoryItem item, int index)
    {
      titleText.text = item.GetDisplayName();
      bodyText.text = item.GetBuyInPrice().ToString();
      thisItem = item;
      thisIndex = index;
    }

    public void ButtonBuy()
    {
      int price = thisItem.GetBuyInPrice();
      if (price <= Money.Instance.GetMoneyHave())
      {
        Money.Instance.AddOrMinusMoney(-thisItem.GetBuyInPrice());

        AddOneToCorrespondingInventory();

      }
      else
      {
        print("oops you dont have enough money to buy this");
      }

    }

    public void ButtonSell()
    {

      Money.Instance.AddOrMinusMoney(thisItem.GetBuyInPrice());
      MinusOneFromCorrespondingInventory();
      print("sell button");
    }

    private void AddOneToCorrespondingInventory()
    {
      // if (thisItem.category == CategoryEnum.Seed)
      // {
      //   GameAssets.seedsInventory.AddToFirstEmptySlot(thisItem, 1);
      // }
      // else if (thisItem.category == CategoryEnum.Produce)
      // {
      //   GameAssets.produceInventory.AddToFirstEmptySlot(thisItem, 1);
      // }
      // else if (thisItem.category == CategoryEnum.Tools)
      // {
      //   GameAssets.toolsInventory.AddToFirstEmptySlot(thisItem, 1);
      // }
    }

    private void MinusOneFromCorrespondingInventory()
    {
      // if (thisItem.category == CategoryEnum.Seed)
      // {
      //   GameAssets.seedsInventory.RemoveFromSlot(thisIndex, 1);
      // }
      // else if (thisItem.category == CategoryEnum.Produce)
      // {
      //   GameAssets.produceInventory.RemoveFromSlot(thisIndex, 1);
      // }
      // else if (thisItem.category == CategoryEnum.Tools)
      // {
      //   GameAssets.toolsInventory.RemoveFromSlot(thisIndex, 1);
      // }
    }

    public void SetupOnlyText(string text)
    {
      // bodyText.text = text;
    }
  }
}
