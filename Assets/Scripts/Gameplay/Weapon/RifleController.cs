using System.Linq;
using UnityEngine;

public class RifleController : BaseWeaponController
{
    [SerializeField] private string weaponKey;
    private Transform gunPointer;

    private void Start()
    {
        var data = Context.Instance.DataSystem.WeaponData.FirstOrDefault(e => e.name == weaponKey);
        gunPointer = GameObject.FindWithTag("GunPointer").transform;
        Init(data, gunPointer);
    }

    public override void OnFireHold()
    {
        Fire();
    }

    public override void OnFirePress() { }
    public override void OnFireRelease() { }
}
