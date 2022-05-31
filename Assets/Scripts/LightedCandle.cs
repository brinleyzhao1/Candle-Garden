using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class LightedCandle : MonoBehaviour
{
  public int lifeTime = 30;
  public int versionNum;
  public Block parentBlock;




  // Start is called before the first frame update
  void Start()
  {
    // _second += Time.deltaTime * timeScale / 2;
    StartCoroutine(BurnDown());
  }

  private IEnumerator BurnDown()
  {
    float timeLeft = lifeTime;
    while (timeLeft > 0.3f)
    {
      int fullHeight = 5;
      if (versionNum == 1)
      {
        fullHeight = 15;
      }
      else if (versionNum == 2)
      {
        fullHeight = 6;
      }

      var localScale = transform.localScale;
      localScale = new Vector3( localScale.x, fullHeight * (timeLeft/lifeTime),localScale.z);
      transform.localScale = localScale;
      yield return new WaitForSeconds(0.2f);
      timeLeft -= 0.2f;
    }

    SelfDestruct();
  }


  private void SelfDestruct()
  {
    // var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
    // vfx.Play();
    // Destroy(vfx.gameObject, vfx.main.duration);


    parentBlock.isEmpty = true;

    Destroy(gameObject);
  }
}
