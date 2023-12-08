public interface IInventorySystem
{
    InventorySlot[] Slots { get; }

    void AddItem(InventoryItem item);
}

public class InventorySystem : IInventorySystem
{
    public const string SaveKey = "inventory";
    public const int InventorySize = 20;

    public InventorySlot[] Slots { get; private set; }

    public InventorySystem()
    {
        Init();

        foreach (var slot in Slots)
        {
            slot.OnSlotChangedEvent += Save;
        }
    }

    private void Init()
    {
        Slots = new InventorySlot[InventorySize];
        var saveData = Context.Instance.SaveSystem.Load<SaveSlots>(SaveKey);

        if (saveData == null)
        {
            for (int i = 0; i < InventorySize; i++)
            {
                Slots[i] = new InventorySlot();
            }
        }
        else
        {
            Slots = SaveSlotConverter.ConvertFromSaveFormat(saveData);
        }

        for (int i = 0; i < InventorySize; i++)
        {
            Slots[i].slotType = InventoryType.All;
        }
    }

    public void Save()
    {
        var saveObject = SaveSlotConverter.ConvertToSaveFormat(Slots);
        Context.Instance.SaveSystem.Save(SaveKey, saveObject);
    }

    public void AddItem(InventoryItem item)
    {
        foreach (var slot in Slots)
        {
            if (slot.IsEmpty)
            {
                slot.Item = item;
                return;
            }
        }
    }
}
