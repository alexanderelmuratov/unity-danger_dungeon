using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryStorage")]
public class InventoryDataStorage : ScriptableObject
{
    public InventoryData[] inventoryData;
}

[Serializable]
public class InventoryData
{
    public InventoryType type;
    public string playerModel;
    public string name;
    public Sprite icon;
    public int armor;
    public int damage;
    public int cure;
}

public enum InventoryType
{
    All,
    Weapon,
    Head,
    Body,
    Legs,
    Shoes,
    Product
}
