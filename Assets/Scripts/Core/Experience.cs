using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{
  public class Experience : MonoBehaviour
  {
    public int currentLevel;
    public int currentExp;
    public int currentMax;

    private Dictionary<int, int> levelToExperience = new Dictionary<int, int>()
    {
      {0, 10},
      {1, 50},
      {2, 100}
    };

    [Header("UI")] [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;

    public void AddExperience(int num)
    {
      currentExp += num;
      if (currentExp >= currentMax)
      {
        currentExp -= levelToExperience[currentLevel];
        currentLevel += 1;
      }
    }

    private void UpdateCurrent()
    {
      currentMax = levelToExperience[currentLevel];
    }


    private void UpdateText()
    {
      levelText.text = "Lvl:" + currentLevel;
      expText.text = currentExp + "/" + currentMax;
    }

    // Start is called before the first frame update
    void Start()
    {
      UpdateCurrent();
      UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
    }
  }
}
