using System;
using Core;
using UnityEngine;


namespace UI
{
  /// <summary>
  /// Responsible for the UI side of inventory.
  /// should sit on "Inventory (Slots Organizer)"
  ///
  /// </summary>
  public class InventoryUi : MonoBehaviour
  {
    // CONFIG DATA
    [SerializeField] protected InventorySlotUi inventorySlotPrefab = null;
    // public CategoryEnum categoryEnum;

    public int slotCircled = -1;

    // CACHE
    private Inventories.Inventory thisInventory;


    private void Start()
    {
      // thisInventory = GameAssets.inventory;//dont know why this grabs null
      thisInventory = FindObjectOfType<Inventories.Inventory>();

      thisInventory.InventoryUpdated += Redraw;

      Redraw();
    }

    private void Update()
    {
      MaintainPreviousCircle();//todo this is a brute force way
    }

    public void HideAllCircles()
    {
      // print("hide all");
      foreach (Transform child in transform)
      {
        child.GetComponent<InventorySlotUi>().HideCircle();
      }
    }


    #region Private

    private void Redraw()
    {
      // print(0);
      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }


      for (int i = 0; i < thisInventory.GetSize(); i++)
      {
        var itemSlotUi = Instantiate(inventorySlotPrefab, transform);
        itemSlotUi.Setup(thisInventory, i);
      }


      MaintainPreviousCircle();
    }

    public void MaintainPreviousCircle()
    {
      if (slotCircled != -1)
      {
        // print("try to reopen");
        var slotShouldBeCircled = transform.GetChild(slotCircled);

        // GameObject circle = slotShouldBeCircled.GetComponent<InventorySlotUi>().circle.gameObject;
        GameObject circle = slotShouldBeCircled.GetChild(1).gameObject;
        // print(circle);
        // print(circle.activeSelf);
        circle.SetActive(true);
        // print("circle opened");
      }
    }

    #endregion
  }
}
