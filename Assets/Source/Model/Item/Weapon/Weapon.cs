using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    private const int _minBullet = 0;

    public readonly Transform MusselPosition;
    public readonly float ShakeIntensity;

    private readonly RecoilWeapon _recoil;
    private readonly ParticleSystem _efectShoot;
    private readonly AudioSource _audioShoot;
    private readonly Action _activeRollbeck;
    private readonly int _maxBullet;

    private bool _isRollbeck = false;

    public int CurentBullet { get; private set; }
    public int AllBullet { get; private set; }

    private bool _isShoot => CurentBullet > _minBullet;

    protected Weapon(List<Vector3> wayRecoilWeapon,Action activeRollbeck,Transform muzzelPosition,ParticleSystem effectShoot,AudioSource audioShoot, AnimatorOverrideController controller, int allBullet, int maxBullet,float shakeIntensity, float speed) : base(controller, speed)
    {
        if (wayRecoilWeapon.Count != maxBullet)
            throw new InvalidOperationException(nameof(wayRecoilWeapon.Count));

        _activeRollbeck = activeRollbeck;
        _efectShoot = effectShoot;
        _audioShoot = audioShoot;
        _maxBullet = maxBullet;
        MusselPosition = muzzelPosition;
        ShakeIntensity = shakeIntensity;
        CurentBullet = maxBullet;
        AllBullet = allBullet;

        _recoil = new RecoilWeapon(MusselPosition,wayRecoilWeapon);
    }

    public void Shoot()
    {
        if (_isShoot == false)
        { 
            if (_isRollbeck == false)
            {
                _isRollbeck = true;
                _activeRollbeck?.Invoke();
                return;
            }

            throw new InvalidOperationException();
        }

        _efectShoot.Play();
        _audioShoot.Play();
        CurentBullet--;
    }

    public void Rollbeck()
    {
        if (CurentBullet == _maxBullet)
            return;

        int numberBullet = CurentBullet - _maxBullet;

        if (numberBullet <= _maxBullet)
        {
            CurentBullet += AllBullet;
            AllBullet = 0;
        }
        else
        {
            CurentBullet += numberBullet;
            AllBullet -= numberBullet;
        }

        _isRollbeck = false;
    }

    public void StopRecoil()
    => _recoil.RestarRecoil();

    public Vector3 GetDirectionBullet()
    => _recoil.GetDirection();
}