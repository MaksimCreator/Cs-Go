public class InputPlayerAttack
{
    private readonly Fsm _fsmWeapon;
    private readonly InventaryPresenter _inventary;

    public InputPlayerAttack(InventaryPresenter inventary, Fsm fsmWeapon)
    {
        _inventary = inventary;
        _fsmWeapon = fsmWeapon;
    }

    public void Update(bool isShoot)
    {
        if (_fsmWeapon.IsState<FsmStateIdelWeapon>() && isShoot)
            _fsmWeapon.SetState<PlayerFsmStateAttack>();
        else if (_fsmWeapon.IsState<PlayerFsmStateAttack>())
            _fsmWeapon.SetState<FsmStateIdelWeapon>();

       _fsmWeapon.Update();
    }

    public void Rollbeck()
    {
        if(_fsmWeapon.IsState<FsmStateIdelWeapon>() ||  _fsmWeapon.IsState<PlayerFsmStateAttack>())
            _fsmWeapon.SetState<PlayerFsmStateRollbeck>();
    }

    public void SwithWeapon(int index)
    {
        if (_inventary.TrySetNumberWeapon(index))
            _fsmWeapon.SetState<FsmStateSwithGun>();
    }
}
