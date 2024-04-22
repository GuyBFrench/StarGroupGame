using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FunctionCounterBehavior : MonoBehaviour
{
    public IntData intData; // Assign the IntData asset in the Inspector
    public int targetValue = 5; // Set the target value to open the new scene

    private void Start()
    {
        // Get the Button component attached to the same GameObject
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Subscribe to the onClick event of the Button
            button.onClick.AddListener(IncrementValue);
        }
    }

    private void IncrementValue()
    {
        intData.UpdateValue(1); // Increment the value by 1
        CheckTargetValue();
    }

    private void CheckTargetValue()
    {
        if (intData.value >= targetValue)
        {
            // Open the new scene
            SceneManager.LoadScene("Scenes/BossLevel");
        }
    }
}