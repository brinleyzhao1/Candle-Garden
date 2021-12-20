using TMPro;
using UnityEngine;

namespace Core
{
  public class Money : MonoBehaviour
  {

    #region Singleton

    public static Money Instance { get; private set; }


    private void Awake()
    {
      if (Instance != null && Instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        Instance = this;
      }

    }

    #endregion


    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private int money;

    private void Start()
    {
      UpdateMoneyUi();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.M)) //todo testing
      {
        AddOrMinusMoney(5);
      }
    }

    public void AddOrMinusMoney(int amount)
    {
      money += amount;
      if (money < 0)
      {
        money = 0;
      }
      UpdateMoneyUi();
    }

    private void UpdateMoneyUi()
    {
      moneyText.text = money.ToString();
    }

    public int GetMoneyHave()
    {
      return money;
    }



  }
}
