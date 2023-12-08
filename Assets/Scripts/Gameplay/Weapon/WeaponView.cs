using TMPro;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI magazineText;
    [SerializeField] private TextMeshProUGUI reserveText;
    private IWeaponController weaponController;

    private void Start()
    {
        weaponController = GameObject.FindWithTag("Player").GetComponent<IWeaponController>();
        weaponController.OnAmmoChangedEvent += OnAmmoChanged;
    }

    private void OnDestroy()
    {
        weaponController.OnAmmoChangedEvent -= OnAmmoChanged;
    }

    private void OnAmmoChanged(int magazineCount, int reserveCount)
    {
        magazineText.text = $"{magazineCount}";
        reserveText.text = $"{reserveCount}";
    }
}
