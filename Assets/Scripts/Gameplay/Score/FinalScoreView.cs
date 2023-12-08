using UnityEngine;

public class FinalScoreView : MonoBehaviour
{
    [SerializeField] private LocalizedTextView localizedScoreText;

    private void Start()
    {
        var score = PlayerPrefs.GetInt("Score", 0);
        localizedScoreText.SetParameters(score);
    }
}
