using System;
using UnityEngine;

public class Inventary
{
    private readonly Item[] _weapons = new Item[3];
    private int _numberWeapon;
    public Item CurentWeapon { get; private set; }

    public Inventary(Knife knife,Gun gun,HeavyWeapons weapon)
    {
        _weapons[0] = knife;
        _weapons[1] = gun;
        _weapons[2] = weapon;
    }

    public AnimatorOverrideController GetAnimationController(int indedxWeapon)
    {
        IsSwithWeapon(indedxWeapon);
        return _weapons[indedxWeapon].AnimationController;
    }

    public void SwithWeapon(int index)
    {
        if (IsSwithWeapon(_numberWeapon))
            CurentWeapon = _weapons[_numberWeapon];
        UpdatePresenter();
    }

    public bool IsSwithWeapon(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if(index >= _weapons.Length)
            throw new ArgumentOutOfRangeException(nameof(index));

        return CurentWeapon.Equals(_weapons[index]) == false;
    }

    protected virtual void UpdatePresenter() { }
}