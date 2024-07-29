public class PhysicsCompositRoot : CompositRoot
{
    public PhysicsRouter Router { get; private set;}

    public override void Init()
    {
        CollisionsRecord rules = new CollisionsRecord();
        Router = new PhysicsRouter(rules.Values);
    }
}
