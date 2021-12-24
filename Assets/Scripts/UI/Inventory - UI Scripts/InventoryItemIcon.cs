using Inventories;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class InventoryItemIcon : MonoBehaviour
  {
    // CONFIG DATA
    [Tooltip("child: Image")] [SerializeField]
    GameObject roundDotImage = null;

    [Tooltip("child: Text")] [SerializeField]
    TextMeshProUGUI itemNumber = null;

    // PUBLIC

    // public void SetItem(InventoryItemIcon itemIcon)
    // {
    //   SetItem(item, 0);
    // }

    public void SetItem(InventoryItem item, int number)
    {
      var iconImage = GetComponent<Image>();
      //set up item image
      if (item == null)
      {
        iconImage.enabled = false;
      }
      else
      {
        iconImage.enabled = true;

        iconImage.sprite = item.GetIcon();
      }


      //set up  number image
      if (itemNumber)
      {
        if (number <= 1)
        {
          roundDotImage.SetActive(false);
        }
        else
        {
          roundDotImage.SetActive(true);
          itemNumber.text = number.ToString();
        }
      }
    }
  }
}
