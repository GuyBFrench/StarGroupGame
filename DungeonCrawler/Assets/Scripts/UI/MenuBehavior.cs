using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
}
