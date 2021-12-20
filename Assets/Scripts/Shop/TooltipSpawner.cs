using System;
using Core;
using Inventory;
using UI;
using UI.Dragging;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
  /// <summary>
  /// Abstract base class that handles the spawning of a tooltip prefab at the
  /// correct position on screen relative to a cursor.
  ///
  /// Override the abstract functions to create a tooltip spawner for your own
  /// data.
  /// </summary>
  [RequireComponent(typeof(Button))]
  public class TooltipSpawner : MonoBehaviour
  {
    // CONFIG DATA
    [Tooltip(
      "The prefab of the tooltip for the shop to spawn. Put shopTooltip for shop slots and sellTooltip for inventory slots.")]
    [SerializeField]
    GameObject tooltipPrefab = null;


    // PRIVATE STATE
    GameObject tooltip = null; // get hold on this slot's specific tooltip


    private void Start()
    {
      Checker();

      GetComponent<Button>().onClick.AddListener(ButtonCreateToolTip);
    }


    /// <summary>
    /// Called when it is time to update the information on the tooltip
    /// prefab.
    /// </summary>
    private void UpdateTooltip()
    {
      var itemTooltip = tooltip.GetComponent<ItemTooltip>();
      if (!itemTooltip) return;

      var item = GetComponent<IItemHolder>().GetItem();
      var index = GetComponent<IItemHolder>().GetIndex();

      itemTooltip.Setup(item, index);
    }

    /// <summary>
    /// Return true when the tooltip spawner should be allowed to create a tooltip.
    /// </summary>
    private bool CanCreateTooltip()
    {
      InventoryItem item = null;

      if (GetComponent<ShopItemEntryUi>()) //for shop
      {
        item = GetComponent<ShopItemEntryUi>().GetItem();
      }
      else if (GetComponent<IItemHolder>() != null) //for inventory
      {
        item = GetComponent<IItemHolder>().GetItem();
      }
      else
      {
        Debug.LogError("neither ShopItemEntryUi nor IItemHolder component exists");
      }

      return item;
    }


    private void ButtonCreateToolTip()
    {
      var parentCanvas = GetComponentInParent<Canvas>();

      if (tooltip && !CanCreateTooltip())
      {
        ClearTooltip();
      }

      if (!tooltip && CanCreateTooltip()) //
      {
        DestroyAllExistingTooltips();
        tooltip = Instantiate(tooltipPrefab, parentCanvas.transform);
        UpdateTooltip();
        PositionTooltip();
      }
      else if (tooltip) //if click again to clear my own tooltip
      {
        ClearTooltip();
      }
    }


    #region Private

    private void OnDestroy()
    {
      ClearTooltip();
    }

    private void OnDisable()
    {
      ClearTooltip();
    }


    private void Checker()
    {
      if (tooltipPrefab == null)
      {
        Debug.LogError("TooltipPrefab is unassigned");
      }
    }

    private void PositionTooltip()
    {
      // Required to ensure corners are updated by positioning elements.
      Canvas.ForceUpdateCanvases();

      var tooltipCorners = new Vector3[4];
      tooltip.GetComponent<RectTransform>().GetWorldCorners(tooltipCorners);

      var slotCorners = new Vector3[4];
      GetComponent<RectTransform>().GetWorldCorners(slotCorners);


      bool below = transform.position.y > Screen.height / 2;
      bool right = transform.position.x < Screen.width / 2;

      int slotCorner = GetCornerIndex(below, right);
      int tooltipCorner = GetCornerIndex(!below, !right);

      tooltip.transform.position =
        slotCorners[slotCorner] * 1f - tooltipCorners[tooltipCorner]*1f + tooltipPrefab.transform.position;
      // tooltip.transform.position =
      //   slotCorners[slotCorner] * 1f - tooltipCorners[tooltipCorner]*1f + tooltip.transform.position;

    }

    private int GetCornerIndex(bool below, bool right)
    {
      if (below && !right) return 0;
      else if (!below && !right) return 1;
      else if (!below && right) return 2;
      else return 3;
    }


    private void ClearTooltip()
    {
      if (tooltip)
      {
        Destroy(tooltip.gameObject);
      }
    }

    private void DestroyAllExistingTooltips()
    {
      var existingTooltips = FindObjectsOfType<ItemTooltip>();
      foreach (var tip in existingTooltips)
      {
        Destroy(tip.gameObject);
      }
    }

    #endregion
  }
}
