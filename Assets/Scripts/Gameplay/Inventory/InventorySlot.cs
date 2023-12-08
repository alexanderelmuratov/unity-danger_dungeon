using System;

public class InventorySlot
{
    public InventoryType slotType;

    private InventoryItem item;
    public InventoryItem Item
    {
        get => item;
        set
        {
            item = value;
            OnSlotChangedEvent?.Invoke();
        }
    }

    public bool IsEmpty => Item == null;

    public event Action OnSlotChangedEvent;

    public static void SwapItems(InventorySlot slot1, InventorySlot slot2)
    {
        if (slot1.IsEmpty && slot2.IsEmpty)
            return;

        if (slot1.IsEmpty || slot2.IsEmpty)
        {
            var emptySlot = slot1.IsEmpty ? slot1 : slot2;
            var filledSlot = slot1.IsEmpty ? slot2 : slot1;

            if (CanPutItem(filledSlot.Item, emptySlot))
                SwapSlots(slot1, slot2);

            return;
        }

        if (CanPutItem(slot1.Item, slot2) && CanPutItem(slot2.Item, slot1))
            SwapSlots(slot1, slot2);
    }

    private static void SwapSlots(InventorySlot slot1, InventorySlot slot2)
    {
        var tempItem = slot1.Item;
        slot1.Item = slot2.Item;
        slot2.Item = tempItem;
    }

    public static bool CanPutItem(InventoryItem item, InventorySlot slot)
    {
        return slot.slotType == InventoryType.All || slot.slotType == item.ItemType;
    }

}
