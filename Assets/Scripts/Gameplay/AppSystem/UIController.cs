using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject storeScreen;
    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Transform root;

    private GameObject currentScreen;

    private void Start()
    {
        var appSystem = Context.Instance.AppSystem;
        appSystem.OnStateChangeEvent += OnStateChange;
        OnStateChange(new(AppState.Loading, appSystem.CurrentState, AppTrigger.ToMainMenu));
        DontDestroyOnLoad(gameObject);
    }

    private void OnStateChange(StateChangeData<AppState, AppTrigger> data)
    {
        if (currentScreen != null)
        {
            Destroy(currentScreen);
        }

        switch (data.NextState)
        {
            case AppState.MainMenu:
                SceneManager.LoadScene("MainMenu");
                currentScreen = Instantiate(mainMenuScreen, root);
                Context.Instance.AudioSystem.PlayMusic(new AudioSettings("menu_background"));
                break;
            case AppState.Store:
                SceneManager.LoadScene("StoreScene");
                currentScreen = Instantiate(storeScreen, root);
                Context.Instance.AudioSystem.PlayMusic(new AudioSettings("store_background"));
                break;
            case AppState.Gameplay:
                SceneManager.LoadScene("GameplayScene");
                currentScreen = Instantiate(gameplayScreen, root);
                Context.Instance.AudioSystem.PlayMusic(new AudioSettings("gameplay_background"));
                break;
            case AppState.WinScreen:
                SceneManager.LoadScene("WinScene");
                currentScreen = Instantiate(winScreen, root);
                Context.Instance.AudioSystem.PlayMusic(new AudioSettings("win_background"));
                break;
            case AppState.LoseScreen:
                SceneManager.LoadScene("LoseScene");
                currentScreen = Instantiate(loseScreen, root);
                Context.Instance.AudioSystem.PlayMusic(new AudioSettings("lose_background"));
                break;
        }
    }
}
