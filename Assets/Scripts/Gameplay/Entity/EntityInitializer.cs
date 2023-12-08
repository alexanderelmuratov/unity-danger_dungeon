using UnityEngine;
using UnityEngine.AI;

public class EntityInitializer : MonoBehaviour
{
    [SerializeField] private string entityKey;
    [SerializeField] private Health health;
    [SerializeField] private Movement movement;
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        var entityData = Context.Instance.DataSystem.EntityData;

        foreach (var data in entityData)
        {
            if (data.name == entityKey)
                Initialize(data);
        }
    }

    public void Initialize(EntityData data)
    {
        health.SetHealth(data.health);

        if (movement != null)
            movement.SetSpeed(data.speed, data.jumpSpeed);

        if (agent != null)
            agent.speed = data.speed;
    }
}
