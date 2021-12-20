using UnityEngine;

namespace Inventory
{
  /// <summary>
  /// An inventory item that can be placed in the action bar and "Used".
  /// actionItem is currently define as all items that can be used in some way.
  /// so far it means seeds, tools and upgrades. Not include produce.
  /// </summary>
  /// <remarks>
  /// This class should be used as a base. Subclasses must implement the `ActionStoreUse` method.
  /// </remarks>
  // [System.Serializable]
  [CreateAssetMenu(menuName = ("Items/Action Item"))]
  public class ActionItem : InventoryItem
  {
    // CONFIG DATA
    [Tooltip("Does an instance of this item get consumed every time it's used.")]
    [SerializeField] bool directlyConsumable = false;

    /// <summary>
    /// Trigger the use of this item. Override to provide functionality.
    /// </summary>
    /// <param name="user">The character that is using this action.</param>
    public virtual void Use(GameObject user)
    {
      //todo add various functions
      Debug.Log("Using action: " + this);

    }

    public bool IsConsumable()
    {
      return directlyConsumable;
    }


  }
}
