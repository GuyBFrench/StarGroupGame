using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        void StartGame()
        {
            // Load the game scene
            SceneManager.LoadScene("GameScene");
        }
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
}
