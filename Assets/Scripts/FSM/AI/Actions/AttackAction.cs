using UnityEngine;

public class AttackAction : BaseAction
{
    public AttackAction(BaseAIController controller) : base(controller)
    {
    }

    public override void Execute()
    {
        controller.agent.destination = controller.transform.position;
        controller.animator.SetDirection(Vector2.zero);
        controller.animator.SetAttack(true);

        var lookPosition = (controller.target.position - controller.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotation, 0.2f);
    }
}
