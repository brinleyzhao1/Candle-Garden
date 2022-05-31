using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Inventories
{
  /// <summary>
  /// A ScriptableObject that represents any item that can be put in an
  /// inventory.
  /// </summary>
  /// <remarks>
  /// In practice, likely to use a subclass such as `ActionItem`, 'Tool'
  ///
  /// </remarks>
  public abstract class InventoryItem : ScriptableObject
  {
    // CONFIG DATA
    [Tooltip("Item name to be displayed in UI.")] [SerializeField]
    string displayName = null;

    public CategoryEnum category = CategoryEnum.Seed;

    public int versionNumber; //which candle/seed. the bigger number the better, start at 1

    [Tooltip("The UI icon to represent this item in the inventory.")] [SerializeField]
    Sprite icon = null;

    [Tooltip("description of the item. one to two sentences")] [SerializeField] [TextArea]
    string description;

    [Tooltip("If true, multiple items of this category can be stacked in the same inventory slot.")] [SerializeField]
    bool stackable = false;

    [Tooltip("price to buy from shop.")] [SerializeField]
     int buyInPrice;
    [Tooltip("price to sell to shop.")] [SerializeField]
     int sellOutPrice;


    // STATE
    static Dictionary<string, InventoryItem> itemLookupCache;

    // PUBLIC


    public Sprite GetIcon()
    {
      return icon;
    }


    public bool IsStackable()
    {
      return stackable;
    }

    public string GetDisplayName()
    {
      return displayName;
    }

    // public string GetDescription()
    // {
    //   return description;
    // }

    public int GetBuyInPrice()
    {
      return buyInPrice;
    }
    public int GetSellOutPrice()
    {
      return sellOutPrice;
    }
  }
}
