public class Context
{
    private static Context instance;
    public static Context Instance => instance ??= new Context();

    public IAppSystem AppSystem { get; private set; }
    public IDataSystem DataSystem { get; private set; }
    public IScoreSystem ScoreSystem { get; private set; }
    public IWinSystem WinSystem { get; private set; }
    public IInventorySystem InventorySystem { get; private set; }
    public IEquipmentSystem EquipmentSystem { get; private set; }
    public ICurrencySystem CurrencySystem { get; private set; }
    public IAudioSystem AudioSystem { get; private set; }
    public ILocalizationSystem LocalizationSystem { get; private set; }
    public ISaveSystem SaveSystem { get; private set; }

    private Context() { }

    public static void Initialize(
        EntityDataStorage entityDataStorage,
        SpawnDataStorage spawnDataStorage,
        WeaponDataStorage weaponDataStorage,
        InventoryDataStorage inventoryDataStorage,
        LootDataStorage lootDataStorage,
        ShopDataStorage shopDataStorage,
        LocalisationDataStorage localisationDataStorage)
    {
        Instance.DataSystem = new DataSystem(
            entityDataStorage,
            spawnDataStorage,
            weaponDataStorage,
            inventoryDataStorage,
            lootDataStorage,
            shopDataStorage,
            localisationDataStorage);
        Instance.SaveSystem = new SaveSystem();
        Instance.AppSystem = new AppSystem();
        Instance.AudioSystem = new AudioSystem();
        Instance.LocalizationSystem = new LocalizationSystem();
        Instance.CurrencySystem = new CurrencySystem();
        Instance.ScoreSystem = new ScoreSystem();
        Instance.InventorySystem = new InventorySystem();
        Instance.EquipmentSystem = new EquipmentSystem();
        Instance.WinSystem = new WinSystem();
    }
}
