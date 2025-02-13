using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int scoreAmount = 100;

    ScoreManager scoreManager;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
        audioManager.PlayCoinUpEffect(0.2f);
    }
}
