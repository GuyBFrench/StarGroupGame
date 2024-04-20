using UnityEngine;
using UnityEngine.UI;

public class CounterBehavior : MonoBehaviour
{
    public IntData intData; // Assign your IntData asset to this field in the Inspector

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(IncrementValue);
    }

    private void IncrementValue()
    {
        intData.UpdateValue(1); // Increment the value by 1 on each button click
        intData.CheckMaxValue(4); // Check for the maximum value of 4
    }
}
