using Inventory;
using TMPro;
using UI;
using UnityEngine;


namespace Core
{
  public class GameAssets : MonoBehaviour
  {
    [Header("Core")] [SerializeField] private PlayerAction setPlayer;
    public static PlayerAction Player;

    #region Audio

    [Header("Audio")] [SerializeField] private AudioSource setSFX;
    public static AudioSource SFX;

    [SerializeField] private AudioClip setLoseHealthSFX;
    public static AudioClip LoseHealthSFX;

    [SerializeField] private AudioClip setErrorSFX;
    public static AudioClip ErrorSFX;

    [SerializeField] private AudioClip setSeedingSFX;
    public static AudioClip SeedingSFX;


    [SerializeField] private AudioClip setPlacingSFX;
    public static AudioClip PlacingSFX;

    #endregion

    #region Candles

    [Header("Candles")] [SerializeField] private GameObject setBabyCandle01;
    public static GameObject BabyCandle01;

    [SerializeField] private GameObject setGrownCandle01;
    public static GameObject GrownCandle01;
    [SerializeField] private GameObject setLightedCandle01;
    public static GameObject LightedCandle01;

    [SerializeField] private TextMeshProUGUI setCandleStockNum;
    public static TextMeshProUGUI CandleStockNumTxt;
    [SerializeField] private TextMeshProUGUI setSeedStockNumTxt;
    public static TextMeshProUGUI SeedStockNumTxt;

    #endregion

    // [Header("Inventory Tabs")]
    // [SerializeField] private GameObject setSeedsTab;
    // public static GameObject seedsTab;
    //
    // [SerializeField] private GameObject setProduceTab;
    // public static GameObject produceTab;
    //
    // [SerializeField] private GameObject setToolsTab;
    // public static GameObject toolsTab;


    #region Inventories

    [Header("Inventories")] [SerializeField]
    private Inventories.Inventory setSeedsInventory;

    public static Inventories.Inventory seedsInventory;

    [SerializeField] private Inventories.Inventory setProduceInventory;
    public static Inventories.Inventory produceInventory;

    [SerializeField] private Inventories.Inventory setToolsInventory;
    public static Inventories.Inventory toolsInventory;

    [SerializeField] private ActionStore setActionStore;
    public static ActionStore actionStore;

    #endregion

    #region Shop Panel

    [Header("shop panel")] [SerializeField]
    private BuySectionUi setBuySection;

    public static BuySectionUi buySection;

    [SerializeField] private ShopItemEntryUi setShopEntryPrefab;
    public static ShopItemEntryUi shopEntry;

    [SerializeField] private GameObject setToolTip;
    public static GameObject ToolTip;

    #endregion

    [Header("core")] [SerializeField] private Money setMoney;
    public static Money money;

    [Header("Miscellaneous")] [SerializeField]
    private GameObject setMatureEffect;

    public static GameObject MatureEffect;

    private void Awake()
    {
      Player = setPlayer;
      BabyCandle01 = setBabyCandle01;
      LightedCandle01 = setLightedCandle01;
      GrownCandle01 = setGrownCandle01;
      SFX = setSFX;
      actionStore = setActionStore;
      shopEntry = setShopEntryPrefab;
      ToolTip = setToolTip;

      LoseHealthSFX = setLoseHealthSFX;
      CandleStockNumTxt = setCandleStockNum;
      SeedStockNumTxt = setSeedStockNumTxt;
      ErrorSFX = setErrorSFX;
      SeedingSFX = setSeedingSFX;
      PlacingSFX = setPlacingSFX;
      // seedsTab = setSeedsTab;
      // produceTab = setProduceTab;
      // toolsTab = setToolsTab;
      seedsInventory = setSeedsInventory;
      produceInventory = setProduceInventory;
      toolsInventory = setToolsInventory;
      buySection = setBuySection;
      money = setMoney;
      MatureEffect = setMatureEffect;
    }
  }
}
