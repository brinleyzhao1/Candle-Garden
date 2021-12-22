using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class Block : MonoBehaviour
{
  public bool isEmpty = true;

  Vector2Int gridPos;

  const int gridSize = 2;
  const string towerParentName = "Towers";

  // [SerializeField] private Orientation _orientation;


  private void Start()
  {
    DestroyAllOtherComponents();
  }

  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(1))
    {
      if (TooFar()) return; //too far

      if (isEmpty)
      {
        if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Seeding)
        {
          PlantCandleSeed();
        }
        else if (GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Placing)
        {
          if (GameAssets.Player.candleStock > 0)
          {
            PlaceMatureCandle();
          }
          else
          {
            //sfx
          }
        }
      }
      else //not empty
      {
        GameAssets.SFX.PlayOneShot(GameAssets.ErrorSFX);
      }
    }
  }

  private void PlaceMatureCandle()
  {

    GameAssets.SFX.PlayOneShot(GameAssets.PlacingSFX);

    var newCandle = Instantiate(GameAssets.GrownCandle01, transform.position, Quaternion.identity);
    newCandle.transform.parent = transform;
    newCandle.transform.position = newCandle.transform.position + new Vector3(0, 2, 0);

    GameAssets.Player.candleStock -= 1;
    GameAssets.CandleStockNumTxt.text = GameAssets.Player.candleStock.ToString();
    isEmpty = false;
  }

  private bool TooFar()
  {
    float distanceFromPlayer = Vector3.Distance(GameAssets.Player.transform.position, transform.position);
    if (distanceFromPlayer > 4)
    {
      return true;
    }

    return false;
  }

  private void PlantCandleSeed()
  {
    if (GameAssets.Player.seedStock <= 0)
    {
      return;
    }

    GameAssets.SFX.PlayOneShot(GameAssets.SeedingSFX);

    var newCandle = Instantiate(GameAssets.BabyCandle01, transform.position, Quaternion.identity);
    newCandle.transform.parent = transform;
    newCandle.transform.position = newCandle.transform.position + new Vector3(0, 2, 0);
    isEmpty = false;

    GameAssets.Player.seedStock -= 1;
    GameAssets.SeedStockNumTxt.text = GameAssets.Player.seedStock.ToString();
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

    // Component[] joints = GetComponents<HingeJoint>() as Component[];
    // foreach(Component joint in joints)
    //   Destroy(joint as HingeJoint);
  }
}
