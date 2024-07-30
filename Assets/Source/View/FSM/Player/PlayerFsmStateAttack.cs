using UnityEngine;

public class PlayerFsmStateAttack : FsmStateAttack
{
    private readonly Camera _player;

    public PlayerFsmStateAttack(Fsm fsm, AnimatorEntity animator, WeaponPresenter presenter,Camera playre, float cooldown) : base(fsm, animator, presenter, cooldown)
    {
        _player = playre;
    }

    protected override Camera GetCamera()
    => _player;
}