using System.Collections.Generic;

public class State
{
    public List<BaseAction> actions = new();
    public List<Transitions<State, BaseCondition>> transitions = new();

    public void Execute()
    {
        foreach (var action in actions)
        {
            action.Execute();
        }
    }

    public State TryGetNextState()
    {
        foreach (var transition in transitions)
        {
            if (transition.Trigger.Evaluate())
            {
                return transition.NextState;
            }
        }

        return default;
    }
}
