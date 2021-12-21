using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class BabyCandle : MonoBehaviour
{
  public int growTime = 30;

  public CandleState state;
  [SerializeField] private AudioClip LighterSound;

  public enum CandleState
  {
    GrowingUp,
    Ready
  }

  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(1))
    {
      if (state == CandleState.Ready && GameAssets.Player.currentActionMode == PlayerAction.ActionMode.Lighter)
      {
        float distanceFromPlayer = Vector3.Distance(GameAssets.Player.transform.position, transform.position);
        if (distanceFromPlayer > 4)
        {
          return; //too far
        }


        LightCandle();
      }
    }
  }

  private void LightCandle()
  {
    GameAssets.SFX.PlayOneShot(LighterSound);

    var newCandle = Instantiate(GameAssets.GrownUpCandle01, transform.position, Quaternion.identity);
    newCandle.transform.parent = transform.parent;
    Destroy(gameObject);
  }

  // Start is called before the first frame update
  void Start()
  {
    // _second += Time.deltaTime * timeScale / 2;
    StartCoroutine(GrowUp());
  }

  private IEnumerator GrowUp()
  {
    state = CandleState.GrowingUp;

    float timeLeft = 0.1f;
    while (timeLeft < growTime)
    {
      transform.localScale = new Vector3(9, 15 * (timeLeft / growTime), 9);
      yield return new WaitForSeconds(0.2f);
      timeLeft += 0.2f;
    }

    state = CandleState.Ready;
  }
}
