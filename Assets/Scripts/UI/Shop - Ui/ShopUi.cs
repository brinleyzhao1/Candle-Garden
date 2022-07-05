using System.Collections.Generic;
using System.Linq;
using Core;
using Inventories;
using UnityEngine;

namespace UI.Shop___Ui
{
  /// <summary>
  /// to be put on the left section of shop UI
  /// in charge of displaying all (icons) of items on sell
  ///
  /// parallel to InventoryUi
  /// </summary>
  public class ShopUi : MonoBehaviour
  {
    // [SerializeField] private Transform shopItemsContainer;

    private List<InventoryItem> allItemsForSell = new List<InventoryItem>();

    public List<InventoryItem> seedsForSell = new List<InventoryItem>();


    public List<InventoryItem> candlesForSell = new List<InventoryItem>();


    public void BtnTabAllItemsForSell()
    {
      SetUpShopList(allItemsForSell);//debug
    }
    public void BtnTabSeedForSell()
    {
      SetUpShopList(seedsForSell);//debug
    }
    public void BtnTabCandleForSell()
    {
      SetUpShopList(candlesForSell);//debug
    }

    private void Start()
    {
      allItemsForSell = candlesForSell.Union(seedsForSell).ToList();
      SetUpShopList(allItemsForSell);//debug
    }

    private void OnEnable()
    {
      SetUpShopList(allItemsForSell);
      // GameAssets.buyCart
      //   .SetDisplayedItem(allItemsForSell[0]); //when first open, automatically show the first item for sell
    }

    private void SetUpShopList(List<InventoryItem> items)
    {
      Checker();

      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }


      foreach (var item in items)
      {
        if (item == null)
          continue;
        ShopItemEntryUi newItem = Instantiate(GameAssets.shopEntry, transform);
        newItem.SetUp(item);
      }
    }


    private void Checker()
    {
      // if (shopItemsContainer == null)
      // {
      //   Debug.LogError("inspector shopItemsContainer in ShopUi is empty");
      // }
      if (allItemsForSell == null)
      {
        Debug.LogError("no items to be sold");
      }
    }



  }
}
