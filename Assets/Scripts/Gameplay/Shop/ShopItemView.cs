using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private string clickSfxKey;
    private ShopData shopData;

    public void SetData(ShopData shopData)
    {
        this.shopData = shopData;
        icon.sprite = shopData.icon;
        price.text = shopData.price.ToString();
    }

    public void Purchase()
    {
        var softCurrency = Context.Instance.CurrencySystem.SoftCurrency;

        if (shopData.price > softCurrency.Amount)
            return;

        softCurrency.Amount -= shopData.price;

        var allItems = Context.Instance.DataSystem.InventoryData;
        var purchsedItem = allItems.FirstOrDefault(i => i.name == shopData.itemName);

        if (purchsedItem != null)
        {
            Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
            Context.Instance.InventorySystem.AddItem(new InventoryItem(purchsedItem));
        }
    }
}
