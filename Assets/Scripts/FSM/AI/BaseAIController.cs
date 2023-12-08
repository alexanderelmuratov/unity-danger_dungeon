using UnityEngine;
using UnityEngine.AI;

public abstract class BaseAIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target = default;
    public IWeaponController weapon;
    public StateMachine<State, object> stateMachine;
    public EntityAnimator animator;

    public Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        target = GameObject.FindWithTag("Player").transform;
        weapon = GetComponent<IWeaponController>();
        stateMachine = GetBehaviour();
    }

    public abstract StateMachine<State, object> GetBehaviour();

    private void Update()
    {
        stateMachine.CurrentState.Execute();
        var nextState = stateMachine.CurrentState.TryGetNextState();

        if (nextState != null)
            stateMachine.CurrentState = nextState;
    }
}
