using UnityEngine;
using System;

public class WeaponPresenter
{
    private readonly Inventary _inventary;
    private readonly SpawnerBullet _spawner;

    public int CurentBullet { get; private set; }
    public int AllBullet { get; private set; }

    public WeaponPresenter(Inventary inventary)
    {
        _inventary = inventary;
    }

    public Transform GetPositionMuzzleWeapon()
    {
        if (_inventary.CurentWeapon is Weapon weapon)
            return weapon.MusselPosition;
        throw new InvalidOperationException();
    }

    public void Shoot(Vector3 position)
    {
        _spawner.Enable(position);

        if (_inventary.CurentWeapon is Weapon weapon)
        {
            weapon.Shoot();
            CurentBullet--;
        }
        else if (_inventary.CurentWeapon is Knife knife)
        {
            knife.Attack();
        }
    }

    public void Rollbeck()
    { 
        if (_inventary.CurentWeapon is Weapon weapon)
        {
            weapon.Rollbeck();
            AllBullet = weapon.AllBullet;
        }
    }

    public void SwithWeapon()
    {
        if (_inventary.CurentWeapon is Weapon weapon)
        {
            CurentBullet = weapon.CurentBullet;
            AllBullet = weapon.AllBullet;
            return;
        }

        CurentBullet = 0;
        AllBullet = 0;
    }
}
