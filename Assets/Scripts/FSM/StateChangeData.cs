public class StateChangeData<TState, TTrigger>
{
    public TState PrevState { get; }
    public TState NextState { get; }
    public TTrigger ByTrigger { get; }

    public StateChangeData(TState prevState, TState nextState, TTrigger byTrigger)
    {
        PrevState = prevState;
        NextState = nextState;
        ByTrigger = byTrigger;
    }
}
