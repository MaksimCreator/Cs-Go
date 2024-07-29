public class InventaryPlayer : Inventary
{
    private readonly WeaponPresenter _presenter;
        
    public InventaryPlayer(Knife knife, Gun gun, HeavyWeapons weapon, WeaponPresenter presenter) : base(knife, gun, weapon)
    {
        _presenter = presenter;
    }

    protected override void UpdatePresenter()
    => _presenter.SwithWeapon();
}
