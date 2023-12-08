using System;
using UnityEngine;

[Serializable]
public class Currency
{
    [SerializeField] private string name;
    [SerializeField] private int amount;

    public string Name => name;
    public int Amount
    {
        get => amount;
        set
        {
            amount = value;
            OnChangedEvent?.Invoke();
        }
    }

    public event Action OnChangedEvent;

    public Currency(string name, int amount)
    {
        this.name = name;
        this.amount = amount;
    }

    public void AddCurrency(int amount)
    {
        Amount += amount;
    }
}
