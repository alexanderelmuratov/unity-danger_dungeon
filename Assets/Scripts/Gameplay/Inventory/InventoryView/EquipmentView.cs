using UnityEngine;

public class EquipmentView : MonoBehaviour
{
    [SerializeField] private InventorySlotView[] slots;
    [SerializeField] private Transform onDragRoot;
    [SerializeField] private SlotsObserver slotsObserver;

    private void Start()
    {
        var slotsData = Context.Instance.EquipmentSystem.Slots;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetData(slotsData[i], onDragRoot, slotsObserver);
        }
    }
}
