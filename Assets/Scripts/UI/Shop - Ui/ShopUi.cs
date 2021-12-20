using System;
using System.Collections.Generic;
using Core;
using Inventory;
using UnityEngine;

namespace UI
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

    public List<InventoryItem> itemsForSell = new List<InventoryItem>();

    private void OnEnable()
    {
      SetUpShopList(itemsForSell);
      // GameAssets.buySection
      //   .SetDisplayedItem(itemsForSell[0]); //when first open, automatically show the first item for sell
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
      if (itemsForSell == null)
      {
        Debug.LogError("no items to be sold");
      }
    }



  }
}
