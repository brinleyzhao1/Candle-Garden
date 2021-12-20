using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class CubeEditor : MonoBehaviour {

  Block block;

  private void Awake()
  {
    block = GetComponent<Block>();
  }

  void Update()
  {
    SnapToGrid();
    UpdateLabel();
  }

  private void SnapToGrid()
  {
    int gridSize = block.GetGridSize();
    transform.position = new Vector3(
      block.GetGridPos().x * gridSize,
      0f,
      block.GetGridPos().y * gridSize
    );
  }

  private void UpdateLabel()
  {
    TextMesh textMesh = GetComponentInChildren<TextMesh>();
    string labelText =
      block.GetGridPos().x +
      "," +
      block.GetGridPos().y;
    textMesh.text = labelText;
    gameObject.name = labelText;
  }
}
