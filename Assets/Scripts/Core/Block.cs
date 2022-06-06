using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Inventories;
using UI;
using UnityEngine;

public class Block : MonoBehaviour
{
  public bool isEmpty = true;
  public float distanceWithinInteract = 4.5f;
  [SerializeField] private GameObject blockCircle;

  Vector2Int gridPos;

  const int gridSize = 2;

  private InventoryUi inventoryUi;


  // [SerializeField] private Orientation _orientation;


  private void Start()
  {
    DestroyAllOtherComponents();
    inventoryUi = FindObjectOfType<InventoryUi>();
  }

  private void OnMouseEnter()
  {
    if (TooFar()) return; //too far
    blockCircle.SetActive(true);
    // if (isEmpty )
    // {
    //   blockCircle.SetActive(true);
    // }
  }

  private void OnMouseExit()
  {
    blockCircle.SetActive(false);
  }

  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(1))
    {
      if (TooFar())
      {
        GameAssets.Feedback.ShowTooFarText();

        return; //too far
      }

      if (isEmpty)
      {
        if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Seeding)
        {
          TryPlantCandleSeed();
        }
        else if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Placing)
        {
          TryPlaceMatureCandle01();
        }
        else //not empty
        {
          GameAssets.SFX.PlayOneShot(GameAssets.ErrorSFX);
        }
      }
    }
  }


  private void TryPlantCandleSeed()
  {

    // InventoryUi inventoryUi = FindObjectOfType<InventoryUi>();
    // inventoryUi.MaintainPreviousCircle();

    GameObject newCandle = null;
    if (GameAssets.Player.actionVersion == 1)
    {
      if (TryRemoveOneFromInventory(GameAssets.SeedObject)) return;
       newCandle = Instantiate(GameAssets.BabyCandle01, transform.position, Quaternion.identity);
       GameAssets.ExperienceSystem.CountExperienceOnAction("grow candle 01");

    }
    else if (GameAssets.Player.actionVersion == 2)
    {
      if (TryRemoveOneFromInventory(GameAssets.SeedObject02)) return;
       newCandle = Instantiate(GameAssets.BabyCandle02, transform.position, Quaternion.identity);
       GameAssets.ExperienceSystem.CountExperienceOnAction("grow candle 02");
    }

    newCandle.transform.parent = transform;
    newCandle.GetComponent<UnlitCandle>().parentBlock = this;
    newCandle.transform.position = newCandle.transform.position + new Vector3(0, 2, 0);
    isEmpty = false;

    GameAssets.SFX.PlayOneShot(GameAssets.SeedingSFX);

  }

  private void TryPlaceMatureCandle01()
  //todo can also place different kind of candles
  {
    if (TryRemoveOneFromInventory(GameAssets.MatureCandle01)) return;

    GameAssets.SFX.PlayOneShot(GameAssets.PlacingSFX);
    //
    var newCandle = Instantiate(GameAssets.GrownCandle01, transform.position, Quaternion.identity);
    newCandle.transform.parent = transform;
    newCandle.GetComponent<UnlitCandle>().parentBlock = this;
    newCandle.transform.position = newCandle.transform.position + new Vector3(0, 2, 0);


    isEmpty = false;
  }

  private static bool TryRemoveOneFromInventory(InventoryItem item)
  {
    int slotInInventory = GameAssets.inventory.HasItem(item);
    if (slotInInventory == -1)
    {
      // print("cannot find slot");
      return true; //couldn't
    }

    GameAssets.inventory.RemoveFromSlot(slotInInventory, 1);


    return false;
  }

  private bool TooFar()
  {
    float distanceFromPlayer = Vector3.Distance(GameAssets.Player.transform.position, transform.position);
    if (distanceFromPlayer > distanceWithinInteract)
    {
      return true;
    }

    return false;
  }


  public int GetGridSize()
  {
    return gridSize;
  }

  public Vector2Int GetGridPos()
  {
    return new Vector2Int(
      Mathf.RoundToInt(transform.position.x / gridSize),
      Mathf.RoundToInt(transform.position.z / gridSize)
    );
  }

  private void DestroyAllOtherComponents()
  {
    var allBlocks = GetComponents<Block>();
    foreach (var block in allBlocks)
    {
      if (block != this)
      {
        Destroy(block);
      }
    }

  }
}
