using System.Linq;
using UnityEngine;

public class PistolController : BaseWeaponController
{
    [SerializeField] private string weaponKey;
    [SerializeField] private Transform gunPointer;

    private void Start()
    {
        var data = Context.Instance.DataSystem.WeaponData.FirstOrDefault(e => e.name == weaponKey);
        Init(data, gunPointer);
    }

    public override void OnFirePress()
    {
        Fire();
    }

    public override void OnFireHold() { }
    public override void OnFireRelease() { }
}
