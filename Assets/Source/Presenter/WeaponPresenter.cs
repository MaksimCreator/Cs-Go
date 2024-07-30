using UnityEngine;
using System;
using DG.Tweening;

public class WeaponPresenter
{
    private readonly Inventary _inventary;
    private readonly SpawnerBullet _spawner;

    private Tween _recoilCamera;

    public int CurentBullet { get; private set; }
    public int AllBullet { get; private set; }

    public WeaponPresenter(Inventary inventary,SpawnerBullet spawner)
    {
        _inventary = inventary;
        _spawner = spawner;
    }

    public Transform GetPositionMuzzleWeapon()
    {
        if (_inventary.CurentWeapon is Weapon weapon)
            return weapon.MusselPosition;
        throw new InvalidOperationException();
    }

    public void ApplayRecoil(Camera camera,float cooldown)
    {
        if (camera == null)
            return;

        if (_inventary.CurentWeapon is Weapon weapon == false)
            return;

        _recoilCamera = CameraRecoil.GetRecoil(camera,cooldown,weapon.ShakeIntensity);
        _recoilCamera.SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    public void StopRecoil()
    {
        if (_recoilCamera == null)
            return;

        if(_inventary.CurentWeapon is Weapon weapon)
            weapon.StopRecoil();

        _recoilCamera.Kill();
    }

    public void Shoot()
    {
        if (_inventary.CurentWeapon is Weapon weapon) 
        {
            weapon.Shoot();
            CurentBullet--;
            _spawner.Enable(GetPositionMuzzleWeapon().position,weapon.GetDirectionBullet());
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
