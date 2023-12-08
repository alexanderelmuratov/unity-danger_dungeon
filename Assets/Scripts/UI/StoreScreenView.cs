using UnityEngine;

public class StoreScreenView : MonoBehaviour
{
    [SerializeField] private string clickSfxKey;

    public void OnBackToMenuClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMainMenu);
    }
}
