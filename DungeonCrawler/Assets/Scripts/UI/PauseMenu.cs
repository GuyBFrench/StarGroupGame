using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuObject; // Reference to the pause menu empty object

    private void Start()
    {
        // Ensure the pause menu is initially hidden
        SetPauseMenuVisible(false);
    }

    public void Pause()
    {
        SetPauseMenuVisible(true);
        SetTimeScale(0f);
    }

    public void Resume()
    {
        SetPauseMenuVisible(false);
        SetTimeScale(1f);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private void SetPauseMenuVisible(bool visible)
    {
        pauseMenuObject.SetActive(visible);
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}

