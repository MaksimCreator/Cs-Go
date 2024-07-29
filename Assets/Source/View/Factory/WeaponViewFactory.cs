using UnityEngine;

public class WeaponViewFactory : ViewFactory<Weapon>
{
    [SerializeField] private GameObject _prefabAk47;
    [SerializeField] private GameObject _prefabUsp;
    [SerializeField] private GameObject _prefabKnife;
    [SerializeField] private GameObject _prefabDigel;

    private WeaponVisiter _visiter;

    private void Awake()
    => _visiter = new WeaponVisiter(_prefabAk47, _prefabUsp, _prefabDigel, _prefabKnife);

    protected override GameObject GetTemplay(Weapon entity)
    {
        _visiter.Visit((dynamic)entity);
        return _visiter.TemplayWeapon;
    }

    protected override Vector3 GetPosition(Vector3 parentPosition)
    => _visiter.TemplayWeapon.transform.position + parentPosition;

    protected override Quaternion GetRotation(Quaternion rotation)
    => Quaternion.Euler(_visiter.TemplayWeapon.transform.eulerAngles + rotation.eulerAngles);

    private class WeaponVisiter : IWeaponVisiter
    {
        private readonly GameObject _ak47;
        private readonly GameObject _usp;
        private readonly GameObject _digel;
        private readonly GameObject _knife;

        public GameObject TemplayWeapon { get; private set; }

        public WeaponVisiter(GameObject ak47, GameObject usp, GameObject digel, GameObject knife)
        {
            _ak47 = ak47;
            _usp = usp;
            _digel = digel;
            _knife = knife;
        }

        public void Visit(Ak47 weapon)
        => TemplayWeapon = _ak47;

        public void Visit(Digle weapon)
        => TemplayWeapon = _digel;

        public void Visit(Usp weapon)
        => TemplayWeapon = _usp;

        public void Visit(Knife weapon)
        => TemplayWeapon = _knife;
    }
}
