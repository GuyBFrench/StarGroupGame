using UnityEngine;
using UnityEngine.Events;

public class MaxValueBehavior : MonoBehaviour
{
    public IntData intData; // Assign the IntData asset in the Inspector

    private void OnEnable()
    {
        intData.maxValueEvent.AddListener(HandleMaxValueReached);
    }

    private void OnDisable()
    {
        intData.maxValueEvent.RemoveListener(HandleMaxValueReached);
    }

    private void HandleMaxValueReached()
    {
        Debug.Log("Maximum value reached!");
        // Perform any desired actions after the maximum value is reached and the value is reset
        // For example, you can open a new scene, display a message, or perform any other logic
    }
}
