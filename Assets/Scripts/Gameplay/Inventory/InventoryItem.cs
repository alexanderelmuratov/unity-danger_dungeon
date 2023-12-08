public class InventoryItem
{
    public InventoryData itemData;
    public int count;

    public InventoryType ItemType => itemData.type;

    public InventoryItem(InventoryData itemData, int count = 1)
    {
        this.itemData = itemData;
        this.count = count;
    }
}
