using System;
using System.Collections;
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

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
        playerController = FindFirstObjectByType<PlayerController>();
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
        playerController.DecreaseMoveSpeed(decreaseMoveSpeedAmount);
        cooldownTimer = 0f;
    }
}
