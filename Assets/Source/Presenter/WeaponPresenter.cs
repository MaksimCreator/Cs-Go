using UnityEngine;
using System;

public class WeaponPresenter
{
    private readonly Inventary _inventary;
    private readonly SpawnerBullet _spawner;
    private readonly IDirectionBullet _entity;

    public int CurentBullet { get; private set; }
    public int AllBullet { get; private set; }

    public WeaponPresenter(Inventary inventary,SpawnerBullet spawner, IDirectionBullet entity)
    {
        _inventary = inventary;
        _spawner = spawner;
        _entity = entity;
    }

    public Transform GetPositionMuzzleWeapon()
    {
        if (_inventary.CurentWeapon is Weapon weapon)
            return weapon.MusselPosition;
        throw new InvalidOperationException();
    }

    public void Shoot(Vector3 position)
    {
        if (_inventary.CurentWeapon is Weapon weapon)
        {
            weapon.Shoot();
            CurentBullet--;
            _spawner.Enable(position,_entity.Direction);
            return;
        }
        else if (_inventary.CurentWeapon is Knife knife)
        {
            knife.Attack();
            return;
        }

        throw new InvalidOperationException();
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
        else if (_inventary.CurentWeapon is Knife)
        {
            CurentBullet = 0;
            AllBullet = 0;
            return;
        }

        throw new InvalidOperationException();
    }
}
