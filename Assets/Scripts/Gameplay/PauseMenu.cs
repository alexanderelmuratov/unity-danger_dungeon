using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private string clickSfxKey;

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMainMenu);
    }
}
