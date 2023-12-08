using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TState, TTrigger>
{
    public TState CurrentState { get; set; }
    public event Action<StateChangeData<TState, TTrigger>> OnStateChangeEvent;
    private Dictionary<TState, List<Transitions<TState, TTrigger>>> transitions = new();

    public StateMachine(TState initialState)
    {
        CurrentState = initialState;
    }

    public void AddTransition(TState fromState, TTrigger byTrigger, TState toState)
    {
        if (!transitions.ContainsKey(fromState))
            transitions.Add(fromState, new());

        foreach (var transition in transitions[fromState])
        {
            if (transition.Trigger.Equals(byTrigger))
            {
                Debug.Log($"The transition from state {CurrentState} by trigger {byTrigger} is already exists.");
                return;
            }
        }

        transitions[fromState].Add(new(toState, byTrigger));
    }

    public void SetTrigger(TTrigger trigger)
    {
        if (!transitions.ContainsKey(CurrentState))
        {
            Debug.Log($"There is no exit from state {CurrentState}.");
            return;
        }

        foreach (var transition in transitions[CurrentState])
        {
            if (transition.Trigger.Equals(trigger))
            {
                var prevState = CurrentState;
                CurrentState = transition.NextState;
                OnStateChangeEvent?.Invoke(new(prevState, CurrentState, trigger));
                return;
            }
        }

        Debug.Log($"There is no exit from state {CurrentState} by trigger {trigger}.");
    }
}
