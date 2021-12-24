using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Inventories;
using Inventory;
using UI;
using UnityEngine;
/// <summary>
/// parallel to ShopItemEntryUi
/// </summary>
[RequireComponent(typeof(InventorySlotUi))]
public class SellSlotUi : MonoBehaviour
{
  private InventoryItem _thisItem;
  private InventorySlotUi inventorySlotUi;
  // Inventories.Inventory inventory;

  private void Start()
  {
    // inventory = FindObjectOfType<Inventories.Inventory>();
    inventorySlotUi = GetComponent<InventorySlotUi>();
  }

  public void BtnSelect()
  {
    GameAssets.sellCart.gameObject.SetActive(true);

    // _thisItem = inventory.GetItemInSlot(index);
    _thisItem = inventorySlotUi.GetItem();
    GameAssets.sellCart.SetDisplayedItem(_thisItem, inventorySlotUi.GetIndex());
  }
}
