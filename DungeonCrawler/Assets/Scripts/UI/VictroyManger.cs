using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    // The number of scenes after which victory screen should appear
    public int scenesUntilVictory = 5;

    // Current number of scenes loaded
    private int scenesLoaded = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Method called when a scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Increment the number of scenes loaded
        scenesLoaded++;

        // Check if the required number of scenes have been loaded
        if (scenesLoaded >= scenesUntilVictory)
        {
            // Load the victory scene
            SceneManager.LoadScene("VictoryScene", LoadSceneMode.Additive);

            // Unsubscribe from the scene loaded event
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
