using UnityEngine;

public class InventaryPresenter : ISpeed
{
    private readonly Inventary _inventar;
    private int _numberWeapon;

    public AnimatorOverrideController OverrideController => _inventar.GetAnimationController(_numberWeapon);
    public float Speed => _inventar.CurentWeapon.Speed;

    public InventaryPresenter(Inventary inventar)
    {
        _inventar = inventar;
    }

    public bool TrySetNumberWeapon(int index)
    {
        if (_inventar.IsSwithWeapon(index))
        {
            _numberWeapon = index;
            return true;
        }

        return false;
    }

    public void SwithWeapon()
    => _inventar.SwithWeapon(_numberWeapon);
}
