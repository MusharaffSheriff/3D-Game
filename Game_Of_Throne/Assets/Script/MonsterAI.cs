using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    public float speed = 2f;
    public float attackDistance = 2f;
    public float health = 100f;

    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        else if (distance == attackDistance)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            // Add death logic here (disable collider, destroy, etc.)
        }
    }
}
