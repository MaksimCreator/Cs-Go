using System;
using UnityEngine;
using System.Collections.Generic;

public class CameraRecoil
{
    private readonly Camera _camera;
    private readonly List<Vector3> _way;
    private readonly float _speed;

    public CameraRecoil(Camera camera, List<Vector3> way, float speed)
    {
        _camera = camera;
        _way = way;
        _speed = speed;
    }

    public void StartRecoil()
    {

    }

    public void StopRecoil()
    {

    }
}
public abstract class Weapon : Item
{
    private const int _minBullet = 0;

    public readonly Transform MusselPosition;
    private readonly ParticleSystem _efectShoot;
    private readonly AudioSource _audioShoot;
    private readonly Action _activeRollbeck;
    private readonly int _maxBullet;

    private bool _isRollbeck = false;

    public int CurentBullet { get; private set; }
    public int AllBullet { get; private set; }

    private bool _isShoot => CurentBullet > _minBullet;

    protected Weapon(Action activeRollbeck,Transform muzzelPosition,ParticleSystem effectShoot,AudioSource audioShoot, AnimatorOverrideController controller, int allBullet, int maxBullet, float speed) : base(controller, speed)
    {
        _activeRollbeck = activeRollbeck;
        MusselPosition = muzzelPosition;
        _efectShoot = effectShoot;
        _audioShoot = audioShoot;
        _maxBullet = maxBullet;
        CurentBullet = maxBullet;
        AllBullet = allBullet;
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
}
