using Inventories;
using Inventory;

namespace UI.Dragging
{
  /// <summary>
  /// Allows the `ItemTooltipSpawner` to display the right information.
  /// </summary>
  public interface IItemHolder
  {
    InventoryItem GetItem();

    int GetIndex();
  }
}
