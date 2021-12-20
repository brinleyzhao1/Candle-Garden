using Core;
using UnityEngine;

namespace UI
{
  public class SwitchTabs : MonoBehaviour
  {
    [SerializeField] private GameObject seedTab;
    [SerializeField] private GameObject produceTab;
    [SerializeField] private GameObject toolTab;

    public void ButtonSwitchToSeedsTab()
    {
      seedTab.SetActive(true);
      produceTab.SetActive(false);
      toolTab.SetActive(false);
    }

    public void ButtonSwitchToProduceTab()
    {
      seedTab.SetActive(false);
      produceTab.SetActive(true);
      toolTab.SetActive(false);
    }

    public void ButtonSwitchToToolsTab()
    {
      seedTab.SetActive(false);
      produceTab.SetActive(false);
      toolTab.SetActive(true);
    }



  }
}
