using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

namespace Core
{
  public class TimeManager : MonoBehaviour
  {
    [Header("time scale tweaking")] [SerializeField]
    private int timeScale = 800; //the bigger the faster in-game time is

    // [SerializeField] private Range fastForwardTimeMultiplier = new Range(1, 2); //
    [SerializeField] [Range(1, 5)] private float fastForwardTimeMultiplier = 1.1f; //

    [Header("Asset Handles")] [SerializeField]
    private Sprite pauseIcon;

    [SerializeField] private Sprite playIcon;
    [SerializeField] private Image pauseButtonImage;

    // public TextMeshProUGUI yearText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI clockText;

    public static int Minute, Hour, Day;

    private static float _second;


    void Start()
    {
      clockText.text = "0:0";
    }

    void Update()
    {
      CalculateTime();
    }


    private void UpdateText()
    {
      dayText.text = Day.ToString();
      //  clockText.text = Hour + ":" + Minute; // display with minute

      if (Hour == 0)
      {
        clockText.text = "12 am";
      }
      else if (Hour < 12)
      {
        clockText.text = Hour + " am";
      }
      else if (Hour == 12)
      {
        clockText.text = "12 pm";
      }
      else
      {
        clockText.text = (Hour - 12) + " pm";
      }
      // yearText.text = Year.ToString();
    }

    private void CalculateTime()
    {
      _second += UnityEngine.Time.deltaTime * timeScale / 2;

      if (_second >= 60)
      {
        Minute++;
        _second = 0;
        UpdateText();
      }
      else if (Minute >= 60)
      {
        Hour++;
        Minute = 0;
        UpdateText();
      }
      else if (Hour >= 24)
      {
        Day++;
        Hour = Hour - 24;
        UpdateText();
      }
      else if (Day > 14)
      {
        // Year++;
        Day = 0;
        UpdateText();
      }
    }

    //currently not used
    public void PauseTimeButton()
    {
      if (Time.timeScale > 0)
      {
        Time.timeScale = 0;
        pauseButtonImage.sprite = playIcon;
      }
      else
      {
        Time.timeScale = 1;
        pauseButtonImage.sprite = pauseIcon;
      }
    }


    //currently not used
    public void FastForwardTimeButton()
    {
      if (Time.timeScale <= 1)
      {
        Time.timeScale = fastForwardTimeMultiplier;
      }
      else
      {
        Time.timeScale = 1;
      }
    }

    public int GetCurrentDay()
    {
      return Day;
    }
  }
}
