using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int chestScore = 500;
    [SerializeField] private RewardGenerator rewardGenerator;
    [SerializeField] private string chestSfxKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Context.Instance.AudioSystem.PlaySFX(new AudioSettings(chestSfxKey, transform.position));
            Context.Instance.ScoreSystem.AddScore(chestScore);
            rewardGenerator.GetReward("RewardChest");
            gameObject.SetActive(false);
        }
    }
}
