using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI count;
    private Transform onDragRoot;
    private Transform defaultParent;
    private InventorySlot slotData;
    private ISlotsObserver slotsObserver;

    private void Start()
    {
        defaultParent = transform.parent;
    }

    public void DisplayItem(InventorySlot slotData, Transform onDragRoot, ISlotsObserver slotsObserver)
    {
        this.slotData = slotData;
        this.onDragRoot = onDragRoot;
        this.slotsObserver = slotsObserver;

        icon.gameObject.SetActive(!slotData.IsEmpty);

        if (!slotData.IsEmpty)
        {
            icon.sprite = slotData.Item.itemData.icon;
            count.text = slotData.Item.count.ToString();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(onDragRoot);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        slotsObserver?.SetOnEndDragSlot(slotData);
        transform.SetParent(defaultParent);
        ((RectTransform)transform).anchoredPosition = Vector2.zero;
    }
}
