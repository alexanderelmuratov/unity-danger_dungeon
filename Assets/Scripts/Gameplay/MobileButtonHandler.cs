using UnityEngine;
using UnityEngine.EventSystems;

public class MobileButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsButtonPressed { get; set; }
    public bool IsButtonHold { get; private set; }
    public bool IsButtonReleased { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsButtonPressed = true;
        IsButtonHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsButtonReleased = true;
        IsButtonHold = false;
    }
}
