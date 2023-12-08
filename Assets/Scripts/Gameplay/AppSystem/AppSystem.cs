using System;

public interface IAppSystem
{
    AppState CurrentState { get; }
    event Action<StateChangeData<AppState, AppTrigger>> OnStateChangeEvent;
    void Trigger(AppTrigger trigger);
}

public class AppSystem : IAppSystem
{
    private StateMachine<AppState, AppTrigger> stateMachine;

    public AppState CurrentState => stateMachine.CurrentState;

    public event Action<StateChangeData<AppState, AppTrigger>> OnStateChangeEvent
    {
        add => stateMachine.OnStateChangeEvent += value;
        remove => stateMachine.OnStateChangeEvent -= value;
    }

    public AppSystem()
    {
        stateMachine = new(AppState.Loading);

        stateMachine.AddTransition(AppState.Loading, AppTrigger.ToMainMenu, AppState.MainMenu);
        stateMachine.AddTransition(AppState.MainMenu, AppTrigger.ToStore, AppState.Store);
        stateMachine.AddTransition(AppState.MainMenu, AppTrigger.ToGameplay, AppState.Gameplay);

        stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToWinScreen, AppState.WinScreen);
        stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToLoseScreen, AppState.LoseScreen);
        stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToMainMenu, AppState.MainMenu);

        stateMachine.AddTransition(AppState.Store, AppTrigger.ToMainMenu, AppState.MainMenu);
        stateMachine.AddTransition(AppState.WinScreen, AppTrigger.ToMainMenu, AppState.MainMenu);
        stateMachine.AddTransition(AppState.LoseScreen, AppTrigger.ToMainMenu, AppState.MainMenu);
    }

    public void Trigger(AppTrigger trigger)
    {
        stateMachine.SetTrigger(trigger);
    }
}

public enum AppState
{
    Loading,
    MainMenu,
    Store,
    Gameplay,
    WinScreen,
    LoseScreen
}

public enum AppTrigger
{
    ToMainMenu,
    ToStore,
    ToGameplay,
    ToWinScreen,
    ToLoseScreen
}
