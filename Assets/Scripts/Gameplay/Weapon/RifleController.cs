using System.Linq;
using UnityEngine;

public class RifleController : BaseWeaponController
{
    [SerializeField] private string weaponKey;

    private void Start()
    {
        var data = Context.Instance.DataSystem.WeaponData.FirstOrDefault(e => e.name == weaponKey);
        Init(data);
    }

    public override void OnFireHold()
    {
        Fire();
    }

    public override void OnFirePress() { }
    public override void OnFireRelease() { }
}
