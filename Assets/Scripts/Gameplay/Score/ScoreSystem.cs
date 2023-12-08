using System;
using UnityEngine;

public interface IScoreSystem
{
    int Score { get; }

    event Action<int> OnScoreChangedEvent;

    void AddScore(int score);

    void ResetScore();
}

public class ScoreSystem : IScoreSystem
{
    public int Score { get; private set; }

    public event Action<int> OnScoreChangedEvent;

    public void AddScore(int score)
    {
        Score += score;
        OnScoreChangedEvent?.Invoke(Score);
        PlayerPrefs.SetInt("Score", Score);
    }

    public void ResetScore()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }
}
