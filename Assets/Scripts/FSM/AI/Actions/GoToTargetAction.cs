using UnityEngine;

public class GoToTargetAction : BaseAction
{
    public GoToTargetAction(BaseAIController controller) : base(controller)
    {
    }

    public override void Execute()
    {
        controller.agent.destination = controller.target.position;
        controller.animator.SetDirection(new Vector2(controller.transform.position.x, controller.transform.position.z));
        controller.animator.SetAttack(false);
    }
}
