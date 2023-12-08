using UnityEngine;

public class RangeEnemy : BaseAIController
{
    [SerializeField] private float aggroRange = 10f;
    [SerializeField] private float fireRange = 7f;
    [SerializeField] private float keepDistanceRange = 3f;

    public override StateMachine<State, object> GetBehaviour()
    {
        var idleState = new State();
        var chaseState = new State();
        var fireState = new State();

        idleState.transitions.Add(new(chaseState, new DistanceCondition(this, aggroRange)));

        chaseState.actions.Add(new GoToTargetAction(this));
        chaseState.transitions.Add(new(fireState, new DistanceCondition(this, fireRange)));

        fireState.actions.Add(new FireAction(this));
        fireState.actions.Add(new KeepDistanceAction(this, keepDistanceRange));
        fireState.transitions.Add(new(chaseState, new DistanceCondition(this, fireRange, false)));

        return new StateMachine<State, object>(idleState);
    }
}
