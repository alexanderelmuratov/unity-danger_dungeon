using UnityEngine;

public class DistanceCondition : BaseCondition
{
    private float distance;
    private bool isLess;

    public DistanceCondition(BaseAIController controller, float distance, bool isLess = true) : base(controller)
    {
        this.distance = distance;
        this.isLess = isLess;
    }

    public override bool Evaluate()
    {
        var currentDistance = Vector3.Distance(controller.transform.position, controller.target.position);

        return isLess ? currentDistance < distance : currentDistance > distance;
    }
}
