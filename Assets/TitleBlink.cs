using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBlink : MonoBehaviour
{
  [SerializeField] private GameObject title;

  [SerializeField] private float onTime;
  [SerializeField] private float offTime;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Blink()
    {
      while (true)
      {
        // print(1);
        yield return new WaitForSeconds(onTime * Random.Range(1,2));

        title.SetActive(false);
        yield return new WaitForSeconds(offTime);
        title.SetActive(true);

      }
    }
}
