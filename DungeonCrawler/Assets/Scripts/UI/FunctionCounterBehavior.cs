using UnityEngine;

public class FunctionCounterBehavior : MonoBehaviour
{
    private int functionCount = 0;
    public IntData functionCountData;

    private void Start()
    {
        // Ensure the function count data is initialized properly
        UpdateFunctionCountData();
    }

    public void CountFunctionCall()
    {
        // Increment the function count
        functionCount++;

        // Update the function count data
        UpdateFunctionCountData();
    }

    private void UpdateFunctionCountData()
    {
        // Update the IntData with the current function count
        functionCountData.SetValue(functionCount);
    }
}

