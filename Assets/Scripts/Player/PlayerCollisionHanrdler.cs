using UnityEngine;

public class PlayerCollisionHanrdler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChengeMoveSpeedAmount = -2f;
    [SerializeField] float decreaseMoveSpeedAmount = 1f;

    const string hitString = "Hit";
    float cooldownTimer = 0;

    LevelGenerator levelGenerator;
    PlayerController playerController;
    AudioManager audioManager;
    GameManager gameManager;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
        playerController = FindFirstObjectByType<PlayerController>();
        audioManager = FindFirstObjectByType<AudioManager>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }



    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChengeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        audioManager.PlayScreamHeroEffect(1f);
        gameManager.DecreaseTimeFromObstacles(other.gameObject.tag);
        playerController.DecreaseMoveSpeed(decreaseMoveSpeedAmount);
        cooldownTimer = 0f;
    }
}
