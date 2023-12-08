using UnityEngine;

public class MainMenuScreenView : MonoBehaviour
{
    [SerializeField] private string clickSfxKey;

    public void OnPlayClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Context.Instance.AppSystem.Trigger(AppTrigger.ToGameplay);
    }

    public void OnStoreClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Context.Instance.AppSystem.Trigger(AppTrigger.ToStore);
    }

    public void OnExitClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Application.Quit();
    }

    public void OnResetProgressClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
