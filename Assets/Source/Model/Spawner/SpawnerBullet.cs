using System;
using UnityEngine;

public class SpawnerBullet : PoolObject<Bullet>
{
    private readonly BulletViewFactory _factory;
    private readonly WeaponPresenter _presenter;

    public SpawnerBullet(BulletViewFactory factroy, WeaponPresenter presenter,int lengch)
    {
        _factory = factroy;
        _presenter = presenter;
    
        InitPool(lengch);
    }

    public void Enable(Vector3 position,Vector3 direction)
    {
        Bullet bullet = Enable(position);
        bullet.AddForceBullet(direction);
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

            model.Init(rb);
            AddObject(model, prefab);
        });
    }

    protected override void Instantiat()
    => Spawn();
}
