using UniRx;
using UnityEngine;

public class FsmStateAttack : FsmState
{
    private readonly ParticleSystem _effectShoot;
    private readonly WeaponPresenter _presenter;
    private readonly float _cooldown;

    private CompositeDisposable _disposable;

    public FsmStateAttack(Fsm fsm, AnimatorEntity animator,WeaponPresenter presenter,ParticleSystem effectShoot,float cooldown) : base(fsm, animator)
    {
        _effectShoot = effectShoot;
        _presenter = presenter;
    }

    public override void Enter()
    {
        Animator.EnterAttack();
        _disposable = Timer.StartInfiniteTimer(_cooldown, () =>
        {
            _effectShoot.Play();
            _presenter.Shoot(_presenter.GetPositionMuzzleWeapon().position);
        });
    }

    public override void Exit()
    => _disposable.Clear();
}
