using System;
using UnityEngine;

public abstract class Weapon : Item
{
    private const int _minBullet = 0;

    public readonly Transform MusselPosition;
    private readonly Action _activeRollbeck;
    private readonly int _maxBullet;

    private bool _isRollbeck = false;

    public int CurentBullet { get; private set; }
    public int AllBullet { get; private set; }

    private bool _isShoot => CurentBullet > _minBullet;

    protected Weapon(Action activeRollbeck,AnimatorOverrideController controller, float speed, int allBullet, int maxBullet, Transform musselPosition) : base(controller, speed)
    {
        _activeRollbeck = activeRollbeck;
        _maxBullet = maxBullet;
        CurentBullet = maxBullet;
        AllBullet = allBullet;
        MusselPosition = musselPosition;

    }

    public void Shoot()
    {
        if (_isShoot)
        {
            if (_isRollbeck == false)
            {
                _activeRollbeck?.Invoke();
                _isRollbeck = true;
            }
            return;
        }

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
