using UnityEngine;
using UnityEngine.UI;

public class CounterBehavior : MonoBehaviour
{
    public IntData intData; // Assign the IntData asset in the Inspector
    public int maxValue = 5; // Set the maximum value

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(IncrementValue);
        }
    }

    private void IncrementValue()
    {
        intData.UpdateValue(1); // Increment the value by 1
        intData.CheckMaxValue(maxValue); // Check for the maximum value
    }
}