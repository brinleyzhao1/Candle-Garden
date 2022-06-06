using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{
  public class Experience : MonoBehaviour
  {
    public int currentLevel = 1;
    public int currentExp;
    public int currentMax;

    private Dictionary<int, int> levelToExperience = new Dictionary<int, int>()
    {
      {1, 50}, //need 50 to get to lvl 1
      {2, 100},
      {3, 200},
      {4, 300}
    };

    private readonly Dictionary<string, int> actionToExperience = new Dictionary<string, int>()
    {
      {"grow candle 01", 10},
      {"grow candle 02", 30},
      {"harvest candle 01", 100},
      {"harvest candle 02", 100}
    };

    [Header("UI")] [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;


    public void CountExperienceOnAction(string action)
    {
      print(action);
      print(actionToExperience[action]);
      int num = actionToExperience[action];
      AddExperience(num);
    }

    private void AddExperience(int num)
    {
      currentExp += num;
      if (currentExp >= currentMax)
      {
        currentExp -= levelToExperience[currentLevel];
        currentLevel += 1;
        UpdateCurrent();

      }

      UpdateText();
      print("added experience");
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
