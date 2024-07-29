using UnityEngine;

public class BulletViewFactory : ViewFactory<Bullet>
{
    [SerializeField] private GameObject _prefab;

    protected override GameObject GetTemplay(Bullet entity)
    => _prefab;
}
