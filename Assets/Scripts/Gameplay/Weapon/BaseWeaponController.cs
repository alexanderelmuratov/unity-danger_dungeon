using System;
using System.Collections;
using UnityEngine;

public interface IWeaponController
{
    void OnFirePress();
    void OnFireHold();
    void OnFireRelease();
    void Fire();

    event Action<int, int> OnAmmoChangedEvent;
}

public abstract class BaseWeaponController : MonoBehaviour, IWeaponController
{
    [SerializeField] private string fireSfxKey;
    [SerializeField] private string reloadSfxKey;
    [SerializeField] private Movement bulletPrefab;

    private Coroutine fireRateRoutine;
    private Coroutine reloadRoutine;
    private Transform gunPointer;
    private ObjectPool<Movement> bulletPool;

    protected Weapon CurrentWeapon { get; set; }

    public event Action<int, int> OnAmmoChangedEvent;

    public abstract void OnFirePress();
    public abstract void OnFireHold();
    public abstract void OnFireRelease();

    protected void Init(WeaponData weaponData, Transform gunPointer)
    {
        CurrentWeapon = new Weapon(weaponData);
        this.gunPointer = gunPointer;
        bulletPool = new ObjectPool<Movement>(bulletPrefab);
    }

    private void Update()
    {
        OnAmmoChangedEvent?.Invoke(CurrentWeapon.AmmoInMagazine, CurrentWeapon.AmmoInReserve);
    }

    public void Fire()
    {
        if (fireRateRoutine != null || CurrentWeapon.IsEmptyMagazine && CurrentWeapon.IsEmptyReserve)
            return;

        if (fireRateRoutine != null || CurrentWeapon.IsEmptyMagazine && !CurrentWeapon.IsEmptyReserve)
        {
            Reload();
            return;
        }

        fireRateRoutine = StartCoroutine(FireRoutine());
    }

    protected IEnumerator FireRoutine()
    {
        Movement bullet = bulletPool.GetObject();
        bullet.transform.position = gunPointer.position;
        bullet.Direction = new Vector2(gunPointer.forward.x, gunPointer.forward.z);

        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(fireSfxKey, transform.position));
        CurrentWeapon.TakeAmmoFromMagazine();
        yield return new WaitForSeconds(CurrentWeapon.FireRate);
        fireRateRoutine = null;
    }

    protected void Reload()
    {
        if (reloadRoutine != null || !CurrentWeapon.IsEmptyMagazine || CurrentWeapon.IsEmptyReserve)
            return;

        reloadRoutine = StartCoroutine(ReloadRoutine());
    }

    protected IEnumerator ReloadRoutine()
    {
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(reloadSfxKey, transform.position));
        yield return new WaitForSeconds(CurrentWeapon.ReloadTime);
        CurrentWeapon.TakeAmmoFromReserve();
        reloadRoutine = null;
    }
}
