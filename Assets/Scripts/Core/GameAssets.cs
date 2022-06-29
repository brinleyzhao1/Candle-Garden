using Inventories;
using UI;
using UnityEngine;


namespace Core
{
  public class GameAssets : MonoBehaviour
  {
    [Header("Core")] [SerializeField] private PlayerAction setPlayer;
    public static PlayerAction Player;

    [SerializeField] private Experience setExperience;
    public static Experience ExperienceSystem;

    #region Audio

    [Header("Audio")] [SerializeField] private AudioSource setSFX;
    public static AudioSource SFX;

    [SerializeField] private AudioClip setLoseHealthSFX;
    public static AudioClip LoseHealthSFX;

    [SerializeField] private AudioClip setErrorSFX;
    public static AudioClip ErrorSFX;

    [SerializeField] private AudioClip setSeedingSFX;
    public static AudioClip SeedingSFX;
    [SerializeField] private AudioClip setHarvestSFX;
    public static AudioClip HarvestSFX;


    [SerializeField] private AudioClip setPlacingSFX;
    public static AudioClip PlacingSFX;
    [SerializeField] private AudioClip setMoneySFX;
    public static AudioClip MoneySFX;
    [SerializeField] private AudioClip setActionSlotSFX;
    public static AudioClip ActionSlotSFX;
    // [SerializeField] private AudioClip setErrorSFX;
    // public static AudioClip errorSFX;

    #endregion

    #region Candles

    [Header("Candles")] [SerializeField] private InventoryItem setSeedObject01;
    public static InventoryItem SeedObject01;
    [SerializeField] private InventoryItem setSeedObject02;
    public static InventoryItem SeedObject02;


    [SerializeField] private GameObject setBabyCandle01;
    public static GameObject BabyCandle01;

    [SerializeField] private GameObject setBabyCandle02;
    public static GameObject BabyCandle02;

    [SerializeField] private GameObject setGrownCandle01;
    public static GameObject GrownCandle01;
    [SerializeField] private GameObject setGrownCandle02;
    public static GameObject GrownCandle02;
    [SerializeField] private GameObject setLightedCandle01;
    public static GameObject LightedCandle01;
    [SerializeField] private GameObject setLightedCandle02;
    public static GameObject LightedCandle02;


    [SerializeField] private InventoryItem setmatureCandle01;

    public static InventoryItem MatureCandle01;

    [SerializeField] private InventoryItem setmatureCandle02;

    public static InventoryItem MatureCandle02;

    // [SerializeField] private TextMeshProUGUI setCandleStockNum;
    // public static TextMeshProUGUI CandleStockNumTxt;
    // [SerializeField] private TextMeshProUGUI setSeedStockNumTxt;
    // public static TextMeshProUGUI SeedStockNumTxt;

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

    [SerializeField] private GameObject setPointToClickEffect;
    public static GameObject PointToClickEffect;

    [SerializeField] private InventoryItem setLighterObject;
    public static InventoryItem LighterObject;

    [SerializeField] private InventoryItem setShovelObject;
    public static InventoryItem ShovelObject;

    [SerializeField] private InventoryItem setSeedObject;
    public static InventoryItem SeedObject;

    [SerializeField] private FeedbackText setFeedbackText;
    public static FeedbackText Feedback;


    private void Awake()
    {
      Player = setPlayer;
      ExperienceSystem = setExperience;


      SeedObject02 = setSeedObject02;
      BabyCandle01 = setBabyCandle01;
      BabyCandle02 = setBabyCandle02;
      LightedCandle01 = setLightedCandle01;
      LightedCandle02 = setLightedCandle02;
      GrownCandle01 = setGrownCandle01;
      GrownCandle02 = setGrownCandle02;
      SFX = setSFX;
      // errorSFX = setErrorSFX;

      shopEntry = setShopEntryPrefab;


      LoseHealthSFX = setLoseHealthSFX;
      // CandleStockNumTxt = setCandleStockNum;
      // SeedStockNumTxt = setSeedStockNumTxt;
      ErrorSFX = setErrorSFX;
      SeedingSFX = setSeedingSFX;
      PlacingSFX = setPlacingSFX;
      MoneySFX = setMoneySFX;
      ActionSlotSFX = setActionSlotSFX;
      HarvestSFX = setHarvestSFX;

      // seedsTab = setSeedsTab;
      // produceTab = setProduceTab;
      // toolsTab = setToolsTab;
      inventory = setInventory;

      MatureCandle01 = setmatureCandle01;
      MatureCandle02 = setmatureCandle02;

      EndGamePanel = setEndGamePanel;

      buyCart = setBuyCart;
      sellCart = setSellCart;

      money = setMoney;
      MatureEffect = setMatureEffect;
      LighterObject = setLighterObject;
      SeedObject = setSeedObject;
      ShovelObject = setShovelObject;

      PointToClickEffect = setPointToClickEffect;
      Feedback = setFeedbackText;
    }
  }
}
