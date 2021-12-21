using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class Block : MonoBehaviour
{

  public bool isPlaceable = true;

  Vector2Int gridPos;

  const int gridSize = 2;
  const string towerParentName = "Towers";

  // [SerializeField] private Orientation _orientation;


  private void Start()
  {
    DestroyAllOtherComponents();
  }

  private void  OnMouseOver () {
    if (Input.GetMouseButtonDown(1))
    {

      float distanceFromPlayer = Vector3.Distance(GameAssets.Player.transform.position, transform.position);
      if (distanceFromPlayer > 4)
      {
        return; //too far
      }

      if (isPlaceable && GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Planting)
      {
        PlantCandle();
      }
    }
  }

  private void PlantCandle()
  {
    var newCandle = Instantiate(GameAssets.BabyCandle01, transform.position, Quaternion.identity);
    newCandle.transform.parent = transform;
    newCandle.transform.position = newCandle.transform.position + new Vector3(0, 2, 0);
    isPlaceable = false;
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
  // public Orientation GetOrientation()
  // {
  //   return _orientation;
  // }

  // void OnMouseOver()
  // {
  //     if (Input.GetMouseButtonDown(0)) // left click
  //     {
  //         print("way point clicked");
  //         // if (isPlaceable)
  //         // {
  //         //     FindObjectOfType<TowerFactory>().AddTower(this);
  //         // }
  //         // else
  //         // {
  //         //     print("Can't place here");
  //         // }
  //     }
  // }
}
