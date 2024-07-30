using UniRx;
using UnityEngine;

public class FsmStateAttack : FsmState
{
    private readonly WeaponPresenter _presenter;
    private readonly float _cooldown;

    private CompositeDisposable _disposable;

    public FsmStateAttack(Fsm fsm, AnimatorEntity animator,WeaponPresenter presenter,float cooldown) : base(fsm, animator)
    {
        _presenter = presenter;
        _cooldown = cooldown;
    }

    public override void Enter()
    {
        _presenter.Shoot();
        _presenter.ApplayRecoil(GetCamera(),_cooldown);
        _disposable = Timer.StartInfiniteTimer(_cooldown, () => _presenter.Shoot());
    }

    public override void Exit()
    {
        _disposable.Dispose();
        _presenter.StopRecoil();
    }

    protected virtual Camera GetCamera() 
    => null;
}