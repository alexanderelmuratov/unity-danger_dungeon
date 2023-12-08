using UnityEngine;

public interface ISlotsObserver
{
    void SetHoveredSlot(InventorySlot slot);
    void SetOnEndDragSlot(InventorySlot slot);
}

public class SlotsObserver : MonoBehaviour, ISlotsObserver
{
    [SerializeField] private string clickSfxKey;
    private InventorySlot currentSlot;

    public void SetHoveredSlot(InventorySlot slot)
    {
        currentSlot = slot;
    }

    public void SetOnEndDragSlot(InventorySlot slot)
    {
        if (currentSlot != null)
        {
            Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
            InventorySlot.SwapItems(currentSlot, slot);
        }
    }
}
