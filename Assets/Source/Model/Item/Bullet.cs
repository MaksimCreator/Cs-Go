using UnityEngine;

public class Bullet
{
    private const int SpeedBullet = 5000;
    public const int Damage = 100;

    private Rigidbody _rbBullet;
    private IDirectionBullet _directionBullet;

    public void Init(Rigidbody rbBullet,IDirectionBullet directionBullet)
    {
        _rbBullet = rbBullet;
        _directionBullet = directionBullet;
    }

    public void AddForceBullet()
    => _rbBullet.AddForce(_directionBullet.Direction * SpeedBullet);
}