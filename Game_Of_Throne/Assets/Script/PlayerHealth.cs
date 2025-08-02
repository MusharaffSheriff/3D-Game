using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Player took damage! Current HP: " + health);
        if (health <= 0)
        {
            Debug.Log("Player is dead.");
            // Handle player death
        }
    }
}