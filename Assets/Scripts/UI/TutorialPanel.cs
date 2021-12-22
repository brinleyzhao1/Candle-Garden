using UnityEngine;

namespace UI
{
  public class TutorialPanel : MonoBehaviour
  {
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.anyKey)
      {
        Time.timeScale = 1;
        gameObject.SetActive(false);
      }
    }
  }
}
