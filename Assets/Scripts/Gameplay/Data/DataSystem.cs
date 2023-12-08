public interface IDataSystem
{
    EntityData[] EntityData { get; }
    SpawnData[] SpawnData { get; }
    WeaponData[] WeaponData { get; }
    InventoryData[] InventoryData { get; }
    LootCollection[] LootData { get; }
    ShopData[] ShopData { get; }
    LocalizationData[] LocalizationData { get; }
}

public class DataSystem : IDataSystem
{
    public EntityData[] EntityData { get; }
    public SpawnData[] SpawnData { get; }
    public WeaponData[] WeaponData { get; }
    public InventoryData[] InventoryData { get; }
    public LootCollection[] LootData { get; }
    public ShopData[] ShopData { get; }
    public LocalizationData[] LocalizationData { get; }

    public DataSystem(
        EntityDataStorage entityDataStorage,
        SpawnDataStorage spawnDataStorage,
        WeaponDataStorage weaponDataStorage,
        InventoryDataStorage inventoryItemData,
        LootDataStorage lootDataStorage,
        ShopDataStorage shopDataStorage,
        LocalisationDataStorage localisationDataStorage)
    {
        EntityData = entityDataStorage.entityData;
        SpawnData = spawnDataStorage.spawnData;
        WeaponData = weaponDataStorage.weaponData;
        InventoryData = inventoryItemData.inventoryData;
        LootData = lootDataStorage.lootData;
        ShopData = shopDataStorage.shopData;
        LocalizationData = localisationDataStorage.localizationData;
    }
}
