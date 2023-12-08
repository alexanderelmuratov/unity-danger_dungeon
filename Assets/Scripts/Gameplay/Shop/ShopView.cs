using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private ShopItemView prefab;

    private void Start()
    {
        var shopData = Context.Instance.DataSystem.ShopData;

        foreach (var data in shopData)
        {
            var itemView = Instantiate(prefab, root);
            itemView.SetData(data);
        }
    }
}
