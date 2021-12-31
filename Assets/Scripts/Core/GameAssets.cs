using Inventories;
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
    [SerializeField] private AudioClip setMoneySFX;
    public static AudioClip MoneySFX;
    [SerializeField] private AudioClip setActionSlotSFX;
    public static AudioClip ActionSlotSFX;

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
    private Inventories.Inventory setInventory;

    public static Inventories.Inventory inventory;

    [SerializeField] private InventoryItem setmatureCandle;

    public static InventoryItem matureCandle;

    #endregion

    #region Shop Panel

    [Header("shop panel")] [SerializeField]
    private BuyCartUi setBuyCart;

    public static BuyCartUi buyCart;

    [SerializeField] private BuyCartUi setSellCart;
    public static BuyCartUi sellCart;

    [SerializeField] private ShopItemEntryUi setShopEntryPrefab;
    public static ShopItemEntryUi shopEntry;

    #endregion

    [Header("core")] [SerializeField] private Money setMoney;
    public static Money money;

    [SerializeField] private EndGame setEndGamePanel;
    public static EndGame EndGamePanel;

    [Header("Miscellaneous")] [SerializeField]
    private GameObject setMatureEffect;
    public static GameObject MatureEffect;

    [SerializeField] private InventoryItem setLighterObject;
    public static InventoryItem LighterObject;

    [SerializeField] private InventoryItem setShovelObject;
    public static InventoryItem ShovelObject;

    [SerializeField] private InventoryItem setSeedObject;
    public static InventoryItem SeedObject;


    private void Awake()
    {
      Player = setPlayer;
      BabyCandle01 = setBabyCandle01;
      LightedCandle01 = setLightedCandle01;
      GrownCandle01 = setGrownCandle01;
      SFX = setSFX;

      shopEntry = setShopEntryPrefab;


      LoseHealthSFX = setLoseHealthSFX;
      CandleStockNumTxt = setCandleStockNum;
      SeedStockNumTxt = setSeedStockNumTxt;
      ErrorSFX = setErrorSFX;
      SeedingSFX = setSeedingSFX;
      PlacingSFX = setPlacingSFX;
      MoneySFX = setMoneySFX;
      ActionSlotSFX = setActionSlotSFX;

      // seedsTab = setSeedsTab;
      // produceTab = setProduceTab;
      // toolsTab = setToolsTab;
      inventory = setInventory;

      matureCandle = setmatureCandle;
      EndGamePanel = setEndGamePanel;

      buyCart = setBuyCart;
      sellCart = setSellCart;

      money = setMoney;
      MatureEffect = setMatureEffect;
      LighterObject = setLighterObject;
      SeedObject = setSeedObject;
      ShovelObject = setShovelObject;
    }
  }
}
