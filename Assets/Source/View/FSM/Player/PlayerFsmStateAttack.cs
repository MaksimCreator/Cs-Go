public class PlayerFsmStateAttack : FsmStateAttack
{
    private readonly CameraRecoil _cameraRecoil;

    public PlayerFsmStateAttack(Fsm fsm, AnimatorEntity animator, WeaponPresenter presenter,CameraRecoil recoiil, float cooldown) : base(fsm, animator, presenter, cooldown)
    {
        _cameraRecoil = recoiil;
    }

    public override void Enter()
    {
        _cameraRecoil.StartRecoil();
        base.Enter();
    }

    public override void Exit()
    {
        _cameraRecoil.StopRecoil();
        base.Exit();
    }
}