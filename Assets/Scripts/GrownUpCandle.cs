using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class GrownUpCandle : MonoBehaviour
{
  public int lifeTime = 30;



  // Start is called before the first frame update
  void Start()
  {
    // _second += Time.deltaTime * timeScale / 2;
    StartCoroutine(BurnDown());
  }

  private IEnumerator BurnDown()
  {
    float timeLeft = lifeTime;
    while (timeLeft > 0)
    {
      transform.localScale = new Vector3( 9, 15 * (timeLeft/lifeTime),9);
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

    Destroy(gameObject);
  }
}
