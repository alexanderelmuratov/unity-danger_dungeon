public class FireAction : BaseAction
{
    public FireAction(BaseAIController controller) : base(controller)
    {
    }

    public override void Execute()
    {
        controller.weapon.Fire();
    }
}
