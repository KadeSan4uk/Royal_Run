using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChengeMoveSpeedAmount = 3f;
    [SerializeField] float increaseTimeIfOnLow = 2f;

    float TimeIsToLow = 5f;

    LevelGenerator levelGenerator;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChengeMoveSpeedAmount);
        if (gameManager.TimeLeft <= TimeIsToLow)
        {
            gameManager.IncreaseTime(increaseTimeIfOnLow);
        }

    }
}
