using UnityEngine;

public class PlayerEquipmentView : MonoBehaviour
{
    [SerializeField] private GameObject defaultPlayer;
    [SerializeField] private GameObject workerPlayer;
    [SerializeField] private GameObject swatPlayer;
    [SerializeField] private GameObject knightPlayer;
    private GameObject currentPlayer;
    private InventorySlot[] slots;

    private void Awake()
    {
        slots = Context.Instance.EquipmentSystem.Slots;

        foreach (var slot in slots)
        {
            slot.OnSlotChangedEvent += DisplayModel;
        }

        DisplayModel();
    }

    private void DisplayModel()
    {
        foreach (var slot in slots)
        {
            if (!slot.IsEmpty && slot.Item.itemData.playerModel == workerPlayer.tag)
            {
                currentPlayer?.SetActive(false);
                currentPlayer = workerPlayer;
                currentPlayer.SetActive(true);
            }
            else if (!slot.IsEmpty && slot.Item.itemData.playerModel == swatPlayer.tag)
            {
                currentPlayer?.SetActive(false);
                currentPlayer = swatPlayer;
                currentPlayer.SetActive(true);
            }
            else if (!slot.IsEmpty && slot.Item.itemData.playerModel == knightPlayer.tag)
            {
                currentPlayer?.SetActive(false);
                currentPlayer = knightPlayer;
                currentPlayer.SetActive(true);
            }
            else
            {
                currentPlayer?.SetActive(false);
                currentPlayer = defaultPlayer;
                currentPlayer.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var slot in slots)
        {
            slot.OnSlotChangedEvent -= DisplayModel;
        }
    }
}
