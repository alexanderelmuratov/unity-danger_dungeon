using System.Linq;
using UnityEngine;

public class RewardGenerator : MonoBehaviour
{
    public void GetReward(string lootKey)
    {
        LootCollection[] lootCollection = Context.Instance.DataSystem.LootData;
        LootItem[] loot = lootCollection.First(l => l.collectionKey == lootKey).lootItems;
        LootItem rewardLoot = default;

        var sum = loot.Select(l => l.weight).Sum();
        var rangeNumber = Random.Range(0, sum);

        for (int i = 0; i < loot.Length; i++)
        {
            if (rangeNumber < loot[i].weight)
            {
                rewardLoot = loot[i];
                break;
            }

            rangeNumber -= loot[i].weight;
        }

        var allItems = Context.Instance.DataSystem.InventoryData;
        var lootItem = allItems.FirstOrDefault(i => i.name == rewardLoot.itemKey);

        if (lootItem != null)
            Context.Instance.InventorySystem.AddItem(new InventoryItem(lootItem));
    }

}
