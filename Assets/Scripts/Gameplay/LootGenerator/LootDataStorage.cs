using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LootStorage")]
public class LootDataStorage : ScriptableObject
{
    public LootCollection[] lootData;
}

[Serializable]
public class LootCollection
{
    public string collectionKey;
    public LootItem[] lootItems;
}

[Serializable]
public class LootItem
{
    public string itemKey;
    public float weight;
}
