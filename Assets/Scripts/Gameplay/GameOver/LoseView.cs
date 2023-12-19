using UnityEngine;

public class LoseView : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    private void Start()
    {
        playerHealth.OnDamagedEvent += OnHealthChanged;
    }

    private void OnDestroy()
    {
        playerHealth.OnDamagedEvent -= OnHealthChanged;
    }

    private void OnHealthChanged(int current, int max)
    {
        if (current <= 0)
        {
            Context.Instance.AppSystem.Trigger(AppTrigger.ToLoseScreen);
        }
    }
}
