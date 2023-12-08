using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image heathBar;

    private void Start()
    {
        health.OnDamagedEvent += onDamaged;
    }

    private void OnDestroy()
    {
        health.OnDamagedEvent -= onDamaged;
    }

    private void onDamaged(int current, int max)
    {
        SetFill((float)current / (float)max);
    }

    private void SetFill(float fillAmount)
    {
        heathBar.fillAmount = fillAmount;
    }
}
