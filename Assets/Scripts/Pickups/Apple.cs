using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChengeMoveSpeedAmount = 3f;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChengeMoveSpeedAmount);
    }
}
