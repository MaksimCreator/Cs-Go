public abstract class FsmState
{
    protected Fsm Fsm;
    protected AnimatorEntity Animator;

    public FsmState(Fsm fsm,AnimatorEntity animator)
    {
        Fsm = fsm;
        Animator = animator;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}