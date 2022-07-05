using System.Collections;
using System.Collections.Generic;
using Core;
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
    StartCoroutine(TakeDamageText());
  }

  private IEnumerator TakeDamageText()
  {
    textContent.text = "not in light! health -5";
    yield return new WaitForSeconds(timeTextOnScreen);
    textContent.text = "";
  }
  public void ShoNoActionSelectedText()
  {
    StartCoroutine(NoActionSelectedText());
  }

  private IEnumerator NoActionSelectedText()
  {
    textContent.text = "No action selected";
    yield return new WaitForSeconds(timeTextOnScreen);
    textContent.text = "";
  }

  public void ShowCannotHarvest()
  {
    StartCoroutine(CannotHarvestText());
  }

  private IEnumerator CannotHarvestText()
  {
    GameAssets.SFX.PlayOneShot(GameAssets.ErrorSFX);

    textContent.text = "cannot harvest if candle isn't fully grown";
    yield return new WaitForSeconds(timeTextOnScreen);
    textContent.text = "";
  }
}
