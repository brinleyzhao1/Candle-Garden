using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackText : MonoBehaviour
{
  [SerializeField] private float timeTextOnScreen = 1f;

  private TextMeshProUGUI textContent;
    // Start is called before the first frame update
    void Start()
    {
      textContent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowTooFarText()
    {
      StartCoroutine(TooFarText());
    }

    public IEnumerator TooFarText()
    {
      textContent.text = "too far";
      yield return new WaitForSeconds(timeTextOnScreen);
      textContent.text = "";
    }
}
