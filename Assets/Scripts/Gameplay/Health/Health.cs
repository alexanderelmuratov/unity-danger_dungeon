using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int scorePerKill = 100;
    [SerializeField] private int goldPerDamage = 10;
    [SerializeField] private string destroySfxKey;

    public int CurrentHealth { get; private set; }
    public event Action<int, int> OnDamagedEvent;

    public void SetHealth(int newHealth)
    {
        maxHealth = newHealth;
        CurrentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;

        OnDamagedEvent?.Invoke(CurrentHealth, maxHealth);

        if (!gameObject.CompareTag("Player"))
        {
            Context.Instance.CurrencySystem.SoftCurrency.AddCurrency(goldPerDamage);

            if (CurrentHealth <= 0)
            {
                Context.Instance.ScoreSystem.AddScore(scorePerKill);
                Context.Instance.AudioSystem.PlaySFX(new AudioSettings(destroySfxKey, transform.position));
                Destroy(gameObject);
            }
        }
    }
}
