using UnityEngine;

public class PatrolAction : BaseAction
{
    private float xPoint;
    private float zPoint;
    private bool isMovingToTarget = true;

    public PatrolAction(BaseAIController controller, float xPoint, float zPoint) : base(controller)
    {
        this.xPoint = xPoint;
        this.zPoint = zPoint;
    }

    public override void Execute()
    {
        var newPositionX = controller.startPosition.x + xPoint;
        var newPositionY = controller.startPosition.y;
        var newPositionZ = controller.startPosition.z + zPoint;

        var newPosition = new Vector3(newPositionX, newPositionY, newPositionZ);

        if (!controller.agent.pathPending && controller.agent.remainingDistance < 0.1f)
        {
            if (isMovingToTarget)
            {
                controller.agent.destination = controller.startPosition;
            }
            else
            {
                controller.agent.destination = newPosition;
            }

            isMovingToTarget = !isMovingToTarget;
        }

        controller.animator.SetDirection(new Vector2(controller.transform.position.x, controller.transform.position.z));
    }
}
