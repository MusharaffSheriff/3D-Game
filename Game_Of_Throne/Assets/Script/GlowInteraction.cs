using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlowInteraction : MonoBehaviour
{
    [Header("Message UI Elements")]
    public GameObject messagePanel; // Assign your MessagePanel GameObject here
    public Text messageText; // Assign your Text (e.g., MessageText) here
    [Header("Message Settings")]
    public string message = "Defeat the enemy in front of you";
    public float messageDuration = 3f;    // Time the message stays visible

    private bool hasInteracted = false;   // Prevents repeat triggering

    private void OnTriggerEnter(Collider other)
    {
        if (hasInteracted) return;

        if (other.CompareTag("Player"))
        {
            hasInteracted = true;

            // Show message UI
            if (messagePanel != null)
                messagePanel.SetActive(true);

            if (messageText != null)
                messageText.text = message;

            // Start coroutine to hide message after duration
            StartCoroutine(HideMessageAfterDelay(messageDuration));
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}