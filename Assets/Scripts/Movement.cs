using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{

  [SerializeField] private AudioSource flyingSFX;
  private Transform _body;


  // Use this for initialization
  void Start()
  {
    // Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
    //   var path = pathfinder.GetPath();
    //   _body = transform.Find("Body");
    //   StartCoroutine(FollowPath(path));
  }

  private void Update()
  {

    if (Input.GetMouseButtonDown(0))
    {
      if (!EventSystem.current.IsPointerOverGameObject())//if not clicked on an UI
      {
        MoveToCursor();
      }

    }

  }

  private void MoveToCursor()
  {
    // GameAssets.SFX.PlayOneShot(GameAssets.FlyingSFX);
    flyingSFX.Play();

    if (Camera.main != null)
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      bool hasHit = Physics.Raycast(ray, out hit);

      if (hasHit)
      {
         GetComponent<NavMeshAgent>().destination = hit.point;
      }


    }
  }


}
