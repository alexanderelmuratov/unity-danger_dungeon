using UnityEngine;

public class GameOverScreenView : MonoBehaviour
{
    [SerializeField] private string clickSfxKey;

    public void OnMenuClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMainMenu);
        Context.Instance.ScoreSystem.ResetScore();
    }

    public void OnExitClick()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        Application.Quit();
    }
}
