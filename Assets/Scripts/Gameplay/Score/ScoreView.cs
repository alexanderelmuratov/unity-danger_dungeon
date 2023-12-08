using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private LocalizedTextView localizedScoreText;

    private void Start()
    {
        Context.Instance.ScoreSystem.OnScoreChangedEvent += OnScoreChanged;
        OnScoreChanged(0);
    }

    private void OnDestroy()
    {
        Context.Instance.ScoreSystem.OnScoreChangedEvent -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        localizedScoreText.SetParameters(score);
    }
}
