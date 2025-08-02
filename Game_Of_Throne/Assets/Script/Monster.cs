using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    public float speed = 2f;
    public float attackDistance = 2f;
    public float health = 100f;
    public float attackRate = 1.5f;

    private float nextAttackTime = 0f;
    private bool isDead = false;

    void Update()
    {
        if (isDead || target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        // If target is out of attack range, walk
        if (distance > attackDistance)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);

            // Move and rotate toward the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        else
        {
            animator.SetBool("isWalking", false);
            

            // Check if attack cooldown is over
            if (Time.time >= nextAttackTime)
            {
                Debug.Log("Monster is attacking!");
                animator.SetBool("isAttacking", true);
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }

    // Called by an Animation Event during the attack animation
    public void DealDamage()
    {
        if (isDead || target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= attackDistance)
        {
            PlayerHealth player = target.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(10f);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            // Disable this script or add ragdoll/death logic here
        }
    }
}