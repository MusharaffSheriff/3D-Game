using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance of GameManager
    public static GameManager Instance;
    [Header("Spawn Points")]
    public Transform playerSpawn;        // Spawn location for the player
    public Transform monsterSpawn;       // Spawn location for the monster

    [Header("Prefabs")]
    public GameObject monsterPrefab;     // The monster to spawn

    [Header("Game State")]
    public int loopCount = 0;            // How many loops (resets) the player has gone through

    void Awake()
    {
        // Ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scene reloads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Call this to spawn the monster in the room
    public void SpawnMonster()
    {
        if (monsterPrefab != null && monsterSpawn != null)
        {
            Instantiate(monsterPrefab, monsterSpawn.position, monsterSpawn.rotation);
        }
        else
        {
            Debug.LogWarning("Monster prefab or spawn point not assigned.");
        }
    }

    // Call this to reset the scene and increase the loop count
    public void ResetLoop()
    {
        loopCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
    }

    // Optional: reset everything and start over
    public void ResetGame()
    {
        loopCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}