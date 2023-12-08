public interface ICurrencySystem
{
    Currency SoftCurrency { get; }
    Currency HardCurrency { get; }
}

public class CurrencySystem : ICurrencySystem
{
    private const string SaveKeySoft = "currency_soft";
    private const string SaveKeyHard = "currency_hard";

    private ISaveSystem saveSystem;

    public Currency SoftCurrency { get; }
    public Currency HardCurrency { get; }

    public CurrencySystem()
    {
        saveSystem = Context.Instance.SaveSystem;

        SoftCurrency = InitCurrency(SaveKeySoft, "Gold", 200);
        HardCurrency = InitCurrency(SaveKeyHard, "Crystal", 10);

        SoftCurrency.OnChangedEvent += Save;
        HardCurrency.OnChangedEvent += Save;
    }

    private Currency InitCurrency(string key, string currencyName, int initAmount)
    {
        var currency = saveSystem.Load<Currency>(key);

        if (currency == null)
            currency = new Currency(currencyName, initAmount);

        return currency;
    }

    private void Save()
    {
        saveSystem.Save(SaveKeySoft, SoftCurrency);
        saveSystem.Save(SaveKeySoft, SoftCurrency);
    }
}
