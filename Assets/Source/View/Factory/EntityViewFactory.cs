using UnityEngine;

public class EntityViewFactory : ViewFactory<Entity>
{
    [SerializeField] private GameObject _prefabTerrorist;
    [SerializeField] private GameObject _prefabContorTerrorist;

    private EnemyVister _enemyVister;

    private void Awake()
    => _enemyVister = new EnemyVister(_prefabTerrorist, _prefabContorTerrorist);

    protected override GameObject GetTemplay(Entity entity)
    {
        _enemyVister.Visit((dynamic)entity);
        return _enemyVister.Prefab;
    }

    private class EnemyVister : IEnemyVisiter
    {
        private readonly GameObject _prefabTerrorist;
        private readonly GameObject _prefabContorTerrorist;

        public GameObject Prefab { get; private set; }

        public EnemyVister(GameObject prefabTerrorist, GameObject prefabContorTerrorist)
        {
            _prefabContorTerrorist = prefabContorTerrorist;
            _prefabTerrorist = prefabTerrorist;
        }

        public void Visit(ContorTerrorist enemy)
        => Prefab = _prefabContorTerrorist;
        public void Visit(Terrorist enemy)
        => Prefab = _prefabTerrorist;
    }
}