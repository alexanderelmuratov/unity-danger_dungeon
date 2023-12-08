using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopStorage")]
public class ShopDataStorage : ScriptableObject
{
    public ShopData[] shopData;
}

[Serializable]
public class ShopData
{
    public string itemName;
    public Sprite icon;
    public int price;
}
