public interface IEquipmentSystem
{
    InventorySlot[] Slots { get; }
}

public class EquipmentSystem : IEquipmentSystem
{
    public const string SaveKey = "equipment";

    public InventorySlot[] Slots { get; private set; }

    public EquipmentSystem()
    {
        Init();

        foreach (var slot in Slots)
        {
            slot.OnSlotChangedEvent += Save;
        }
    }

    private void Init()
    {
        var saveData = Context.Instance.SaveSystem.Load<SaveSlots>(SaveKey);

        if (saveData == null)
        {
            Slots = new InventorySlot[]
            {
                new InventorySlot(),
                new InventorySlot(),
                new InventorySlot(),
                new InventorySlot(),
            };
        }
        else
        {
            Slots = SaveSlotConverter.ConvertFromSaveFormat(saveData);
        }

        Slots[0].slotType = InventoryType.Weapon;
        Slots[1].slotType = InventoryType.Head;
        Slots[2].slotType = InventoryType.Body;
        Slots[3].slotType = InventoryType.Shoes;
    }

    public void Save()
    {
        var saveObject = SaveSlotConverter.ConvertToSaveFormat(Slots);
        Context.Instance.SaveSystem.Save(SaveKey, saveObject);
    }
}
