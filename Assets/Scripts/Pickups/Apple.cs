using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChengeMoveSpeedAmount = 3f;
    [SerializeField] float increaseTimeIfOnLow = 2f;
    [SerializeField] float increaseMoveSpeedAmount = 1f;

    float TimeIsToLow = 5f;

    LevelGenerator levelGenerator;
    GameManager gameManager;
    PlayerController playerController;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerController = FindFirstObjectByType<PlayerController>();
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

        playerController.IncreaseMoveSpeed(increaseMoveSpeedAmount);

    }
}
