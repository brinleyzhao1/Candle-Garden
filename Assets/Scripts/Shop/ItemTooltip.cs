using Core;
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
      bodyText.text = item.GetPrice().ToString();
      thisItem = item;
      thisIndex = index;
    }

    public void ButtonBuy()
    {
      int price = thisItem.GetPrice();
      if (price <= Money.Instance.GetMoneyHave())
      {
        Money.Instance.AddOrMinusMoney(-thisItem.GetPrice());

        AddOneToCorrespondingInventory();

      }
      else
      {
        print("oops you dont have enough money to buy this");
      }

    }

    public void ButtonSell()
    {

      Money.Instance.AddOrMinusMoney(thisItem.GetPrice());
      MinusOneFromCorrespondingInventory();
      print("sell button");
    }

    private void AddOneToCorrespondingInventory()
    {
      if (thisItem.type == CategoryEnum.Seed)
      {
        GameAssets.seedsInventory.AddToFirstEmptySlot(thisItem, 1);
      }
      else if (thisItem.type == CategoryEnum.Produce)
      {
        GameAssets.produceInventory.AddToFirstEmptySlot(thisItem, 1);
      }
      else if (thisItem.type == CategoryEnum.Tools)
      {
        GameAssets.toolsInventory.AddToFirstEmptySlot(thisItem, 1);
      }
    }

    private void MinusOneFromCorrespondingInventory()
    {
      if (thisItem.type == CategoryEnum.Seed)
      {
        GameAssets.seedsInventory.RemoveFromSlot(thisIndex, 1);
      }
      else if (thisItem.type == CategoryEnum.Produce)
      {
        GameAssets.produceInventory.RemoveFromSlot(thisIndex, 1);
      }
      else if (thisItem.type == CategoryEnum.Tools)
      {
        GameAssets.toolsInventory.RemoveFromSlot(thisIndex, 1);
      }
    }

    public void SetupOnlyText(string text)
    {
      // bodyText.text = text;
    }
  }
}
