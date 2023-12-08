using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventorySlotView[] slots;
    [SerializeField] private Transform onDragRoot;
    [SerializeField] private SlotsObserver slotsObserver;

    private void Start()
    {
        var slotsData = Context.Instance.InventorySystem.Slots;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetData(slotsData[i], onDragRoot, slotsObserver);
        }
    }
}
