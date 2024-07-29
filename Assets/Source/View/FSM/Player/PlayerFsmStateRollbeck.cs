using UniRx;

public class PlayerFsmStateRollbeck : FsmState
{
    private CompositeDisposable _disposables = new();
    private readonly WeaponPresenter _weapon;

    public PlayerFsmStateRollbeck(Fsm fsm, AnimatorEntity animator,WeaponPresenter weapon) : base(fsm, animator) 
    {
        _weapon = weapon;
    }

    public override void Enter()
    {
        Animator.EnterRollbeck();
        _disposables = Timer.StartTimer(Animator.GetLenghAnimationRollbeck(), () => 
        {
            _weapon.Rollbeck();
            Fsm.SetState<FsmStateIdelWeapon>();
        });
    }

    public override void Exit()
    => _disposables.Clear();
}