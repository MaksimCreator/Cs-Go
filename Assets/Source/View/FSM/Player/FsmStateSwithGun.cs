public class FsmStateSwithGun : FsmState
{
    private readonly InventaryPresenter _inventary;

    public FsmStateSwithGun(Fsm fsm, AnimatorEntity animator,InventaryPresenter inventary) : base(fsm, animator) 
    {
        _inventary = inventary;
    }

    public override void Enter()
    {
        Animator.EnterSwithGun(_inventary.OverrideController);
        Timer.StartTimer(Animator.GetLenghAnimationSwithGun(_inventary.OverrideController), () =>
        {
            _inventary.SwithWeapon();
            Fsm.SetState<FsmStateIdelWeapon>();
        });
    }
}
