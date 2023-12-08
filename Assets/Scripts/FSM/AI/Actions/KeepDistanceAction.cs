using UnityEngine;

public class KeepDistanceAction : BaseAction
{
    private float distance;

    public KeepDistanceAction(BaseAIController controller, float distance) : base(controller)
    {
        this.distance = distance;
    }

    public override void Execute()
    {
        var direction = (controller.target.position - controller.transform.position).normalized;
        direction *= distance;
        controller.agent.destination = controller.target.position - direction;

        if (controller.transform.position == controller.target.position - direction)
            controller.animator.SetDirection(Vector2.zero);
        else
            controller.animator.SetDirection(new Vector2(controller.transform.position.x, controller.transform.position.z));

        var lookPosition = (controller.target.position - controller.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotation, 0.2f);
    }
}
