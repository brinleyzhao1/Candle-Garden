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

    private IEnumerator TooFarText()
    {
      textContent.text = "too far";
      yield return new WaitForSeconds(timeTextOnScreen);
      textContent.text = "";
    }
    public void ShowTakeDamageText()
    {
      StartCoroutine( TakeDamageText());
    }

    private IEnumerator TakeDamageText()
    {
      textContent.text = "not in light! health -5";
      yield return new WaitForSeconds(timeTextOnScreen);
      textContent.text = "";
    }
}
