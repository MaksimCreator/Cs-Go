using UnityEngine;

public class Bullet
{
    private const int SpeedBullet = 5000;
    public const int Damage = 100;

    private Rigidbody _rbBullet;

    public void Init(Rigidbody rbBullet)
    {
        _rbBullet = rbBullet;
    }

    public void AddForceBullet(Vector3 direction)
    => _rbBullet.AddForce(direction * SpeedBullet);
}