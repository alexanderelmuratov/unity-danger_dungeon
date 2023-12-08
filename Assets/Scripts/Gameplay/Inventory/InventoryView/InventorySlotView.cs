using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryItemView itemView;
    private InventorySlot slotData;
    private Transform onDragRoot;
    private ISlotsObserver slotsObserver;

    public void SetData(InventorySlot slotData, Transform onDragRoot, ISlotsObserver slotsObserver)
    {
        this.slotData = slotData;
        this.onDragRoot = onDragRoot;
        this.slotsObserver = slotsObserver;
        this.slotData.OnSlotChangedEvent += DisplaySlot;
        DisplaySlot();
    }

    private void OnDestroy()
    {
        if (slotData != null)
            slotData.OnSlotChangedEvent -= DisplaySlot;
    }

    private void DisplaySlot()
    {
        itemView.DisplayItem(slotData, onDragRoot, slotsObserver);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slotsObserver?.SetHoveredSlot(slotData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotsObserver?.SetHoveredSlot(null);
    }
}
