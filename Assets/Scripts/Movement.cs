﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
  [SerializeField] float movementPeriod = .5f;
  [SerializeField] ParticleSystem goalParticle;
  private Transform _body;

  [SerializeField] private Transform Target;


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
      MoveToCursor();
    }

  }

  private void MoveToCursor()
  {
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

  IEnumerator FollowPath(List<Waypoint> path)
  {
    foreach (Waypoint waypoint in path)
    {
      transform.position = waypoint.transform.position + new Vector3(0, 2, 0);
      TurnToRoadDirection(waypoint);
      yield return new WaitForSeconds(movementPeriod);
    }
  }

  private void TurnToRoadDirection(Waypoint waypoint)
  {
    // if (waypoint.GetOrientation() == Orientation.Right)
    // {
    //   _body.rotation = Quaternion.Euler(0,90,0);
    // }
    // else if (waypoint.GetOrientation() == Orientation.Left)
    // {
    //   _body.rotation = Quaternion.Euler(0,-90,0);
    // }
    // else if (waypoint.GetOrientation() == Orientation.Down)
    // {
    //   _body.rotation = Quaternion.Euler(0,180,0);
    // }
    // else if (waypoint.GetOrientation() == Orientation.Up)
    // {
    //   _body.rotation = Quaternion.Euler(0,0,0);
    // }
  }
}
