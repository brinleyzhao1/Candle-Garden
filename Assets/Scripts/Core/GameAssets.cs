using Inventory;
using UI;
using UnityEngine;


namespace Core
{
  public class GameAssets : MonoBehaviour
  {
    [Header("Core")] [SerializeField] private PlayerAction setPlayer;
    public static PlayerAction Player;

    [Header("Audio")]
    [SerializeField] private AudioSource setSFX;
    public static AudioSource SFX;

    [Header("Candles")] [SerializeField] private GameObject setBabyCandle01;
    public static GameObject BabyCandle01;
    [SerializeField] private GameObject setGrownUpCandle01;
    public static GameObject GrownUpCandle01;

    // [Header("Inventory Tabs")]
    // [SerializeField] private GameObject setSeedsTab;
    // public static GameObject seedsTab;
    //
    // [SerializeField] private GameObject setProduceTab;
    // public static GameObject produceTab;
    //
    // [SerializeField] private GameObject setToolsTab;
    // public static GameObject toolsTab;

    [Header("Inventories")] [SerializeField]
    private Inventories.Inventory setSeedsInventory;

    public static Inventories.Inventory seedsInventory;

    [SerializeField] private Inventories.Inventory setProduceInventory;
    public static Inventories.Inventory produceInventory;

    [SerializeField] private Inventories.Inventory setToolsInventory;
    public static Inventories.Inventory toolsInventory;

    [SerializeField] private ActionStore setActionStore;
    public static ActionStore actionStore;

    [Header("shop panel")] [SerializeField]
    private BuySectionUi setBuySection;

    public static BuySectionUi buySection;

    [SerializeField] private ShopItemEntryUi setShopEntryPrefab;
    public static ShopItemEntryUi shopEntry;

    [SerializeField] private GameObject setToolTip;
    public static GameObject ToolTip;

    [Header("core")] [SerializeField] private Money setMoney;
    public static Money money;

    private void Awake()
    {
      Player = setPlayer;
      BabyCandle01 = setBabyCandle01;
      GrownUpCandle01 = setGrownUpCandle01;
      SFX = setSFX;
      actionStore = setActionStore;
      shopEntry = setShopEntryPrefab;
      ToolTip = setToolTip;
      // seedsTab = setSeedsTab;
      // produceTab = setProduceTab;
      // toolsTab = setToolsTab;
      seedsInventory = setSeedsInventory;
      produceInventory = setProduceInventory;
      toolsInventory = setToolsInventory;
      buySection = setBuySection;
      money = setMoney;
    }
  }
}
