using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMoving : MonoBehaviour
{
  [SerializeField] private float smallZ;
  [SerializeField] private float largeZ;

  [SerializeField] private float speed = 1f;

  private bool movingForward;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (movingForward)
      {
        transform.position += new Vector3(0,0,Time.deltaTime * speed);
      }
      else
      {
        transform.position -= new Vector3(0,0,Time.deltaTime * speed);
      }

      if (transform.position.z >= largeZ)
      {
        movingForward = false;
      }

      if (transform.position.z <= smallZ)
      {
        movingForward = true;
      }

    }
}
