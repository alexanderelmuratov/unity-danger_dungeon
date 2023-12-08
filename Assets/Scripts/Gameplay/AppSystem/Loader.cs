using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private EntityDataStorage entityDataStorage;
    [SerializeField] private SpawnDataStorage spawnDataStorage;
    [SerializeField] private WeaponDataStorage weaponDataStorage;
    [SerializeField] private InventoryDataStorage inventoryDataStorage;
    [SerializeField] private LootDataStorage lootDataStorage;
    [SerializeField] private ShopDataStorage shopDataStorage;
    [SerializeField] private LocalisationDataStorage localisationDataStorage;


    private void Awake()
    {
        Context.Initialize(
            entityDataStorage,
            spawnDataStorage,
            weaponDataStorage,
            inventoryDataStorage,
            lootDataStorage,
            shopDataStorage,
            localisationDataStorage);
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMainMenu);
    }
}
