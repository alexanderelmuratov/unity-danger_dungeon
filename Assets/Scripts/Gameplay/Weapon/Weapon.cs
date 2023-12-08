public class Weapon
{
    public WeaponData WeaponData { get; }
    public string WeaponName { get; }
    public int AmmoInMagazine { get; private set; }
    public int AmmoInReserve { get; private set; }
    public float FireRate { get; }
    public float ReloadTime { get; }
    public bool IsEmptyMagazine => AmmoInMagazine <= 0;
    public bool IsEmptyReserve => AmmoInReserve <= 0;

    public Weapon(WeaponData weaponData)
    {
        WeaponData = weaponData;
        AmmoInMagazine = WeaponData.maxAmmoInMagazine;
        AmmoInReserve = WeaponData.maxAmmoInReserve;
        FireRate = WeaponData.fireRate;
        ReloadTime = WeaponData.reloadTime;
    }

    public void TakeAmmoFromMagazine()
    {
        AmmoInMagazine--;
    }

    public void TakeAmmoFromReserve()
    {
        if (AmmoInMagazine + AmmoInReserve > WeaponData.maxAmmoInMagazine)
        {
            var ammoToTake = WeaponData.maxAmmoInMagazine - AmmoInMagazine;
            AmmoInReserve -= ammoToTake;
            AmmoInMagazine = WeaponData.maxAmmoInMagazine;
        }
        else
        {
            AmmoInMagazine += AmmoInReserve;
            AmmoInReserve = 0;
        }
    }
}
