using System;
using System.Linq;

public static class SaveSlotConverter
{
    public static SaveSlots ConvertToSaveFormat(InventorySlot[] slots)
    {
        var saveSlots = new SaveSlots();
        saveSlots.slotItems = new SaveSlotItem[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            var id = slots[i].IsEmpty ? "" : slots[i].Item.itemData.name;
            var count = slots[i].IsEmpty ? 0 : slots[i].Item.count;

            saveSlots.slotItems[i] = new SaveSlotItem() { itemId = id, itemCount = count };
        }

        return saveSlots;
    }

    public static InventorySlot[] ConvertFromSaveFormat(SaveSlots saveSlots)
    {
        var slots = new InventorySlot[saveSlots.slotItems.Length];
        var inventoryData = Context.Instance.DataSystem.InventoryData;
        var saveSlotItems = saveSlots.slotItems;

        for (int i = 0; i < saveSlotItems.Length; i++)
        {
            slots[i] = new InventorySlot();
            var itemData = inventoryData.FirstOrDefault(d => d.name == saveSlotItems[i].itemId);

            if (itemData != null)
                slots[i].Item = new InventoryItem(itemData, saveSlotItems[i].itemCount);
        }

        return slots;
    }
}

[Serializable]
public class SaveSlots
{
    public SaveSlotItem[] slotItems;
}

[Serializable]
public class SaveSlotItem
{
    public string itemId;
    public int itemCount;
}
