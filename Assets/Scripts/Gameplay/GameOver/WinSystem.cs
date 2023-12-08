public interface IWinSystem
{
}

public class WinSystem : IWinSystem
{
    private const int WinScore = 1500;

    public WinSystem()
    {
        Context.Instance.ScoreSystem.OnScoreChangedEvent += OnScoreChanged;
    }

    public void OnScoreChanged(int score)
    {
        if (score >= WinScore)
        {
            Context.Instance.CurrencySystem.HardCurrency.AddCurrency(1);
            Context.Instance.AppSystem.Trigger(AppTrigger.ToWinScreen);
        }
    }
}
