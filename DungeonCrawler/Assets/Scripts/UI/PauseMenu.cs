using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseMenuCanvasGroup;

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

    public void Menu(int sceneID)
    {
        SetTimeScale(1f);
        SceneManager.LoadScene(sceneID);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private void SetPauseMenuVisible(bool visible)
    {
        pauseMenuCanvasGroup.interactable = visible;
        pauseMenuCanvasGroup.blocksRaycasts = visible;
        pauseMenuCanvasGroup.alpha = visible ? 1 : 0; // Optionally, you can fade in/out the pause menu
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}

