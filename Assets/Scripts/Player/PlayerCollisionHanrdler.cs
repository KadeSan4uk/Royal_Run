using System;
using System.Collections;
using UnityEngine;

public class PlayerCollisionHanrdler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;

    float cooldownTimer = 0;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    const string hitString = "Hit";

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}
