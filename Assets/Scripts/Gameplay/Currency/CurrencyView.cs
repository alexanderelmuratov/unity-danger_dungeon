using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private bool isSoft;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI amount;
    private Currency currency;

    private void Start()
    {
        currency = isSoft
            ? Context.Instance.CurrencySystem.SoftCurrency
            : Context.Instance.CurrencySystem.HardCurrency;

        currency.OnChangedEvent += SetAmount;
        SetAmount();
    }

    private void OnDestroy()
    {
        currency.OnChangedEvent -= SetAmount;
    }

    private void SetAmount()
    {
        amount.text = currency.Amount.ToString();
    }
}
