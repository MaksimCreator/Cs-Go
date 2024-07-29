using System;
using UnityEngine;

public class SpawnerBullet : PoolObject<Bullet>
{
    private readonly BulletViewFactory _factory;
    private readonly WeaponPresenter _presenter;
    private readonly IDirectionBullet _direction;

    public SpawnerBullet(BulletViewFactory factroy, WeaponPresenter presenter, IDirectionBullet direction,int lengch)
    {
        _factory = factroy;
        _presenter = presenter;
        _direction = direction;

        InitPool(lengch);
    }

    public new void Enable(Vector3 position)
    {
        Bullet bullet = base.Enable(position);
        bullet.AddForceBullet();
    }

    private void InitPool(int lengch)
    {
        for (int i = 0; i < lengch; i++)
            Spawn();
    }

    private void Spawn()
    {
        _factory.Creat(_presenter.GetPositionMuzzleWeapon(), new Bullet(), (model, prefab) =>
        {
            if (prefab.TryGetComponent(out Rigidbody rb) == false)
                throw new InvalidOperationException();

            model.Init(rb, _direction);
            AddObject(model, prefab);
        });
    }

    protected override void Instantiat()
    => Spawn();
}
