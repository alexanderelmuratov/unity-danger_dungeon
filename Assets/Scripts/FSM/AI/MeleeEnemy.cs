using UnityEngine;

public class MeleeEnemy : BaseAIController
{
    [SerializeField] private float aggroRange = 10f;
    [SerializeField] private float attackRange = 2.5f;
    [SerializeField] private float xDirection = 38f;
    [SerializeField] private float zDirection = 0f;

    public override StateMachine<State, object> GetBehaviour()
    {
        var patrolState = new State();
        var chaseState = new State();
        var attackState = new State();

        patrolState.actions.Add(new PatrolAction(this, xDirection, zDirection));
        patrolState.transitions.Add(new(chaseState, new DistanceCondition(this, aggroRange)));

        chaseState.actions.Add(new GoToTargetAction(this));
        chaseState.transitions.Add(new(attackState, new DistanceCondition(this, attackRange)));

        attackState.actions.Add(new AttackAction(this));
        attackState.transitions.Add(new(chaseState, new DistanceCondition(this, attackRange, false)));

        return new StateMachine<State, object>(patrolState);
    }
}
