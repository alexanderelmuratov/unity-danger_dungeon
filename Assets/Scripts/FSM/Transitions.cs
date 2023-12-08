public class Transitions<TState, TTrigger>
{
    public TState NextState { get; }
    public TTrigger Trigger { get; }

    public Transitions(TState nextState, TTrigger trigger)
    {
        NextState = nextState;
        Trigger = trigger;
    }
}
