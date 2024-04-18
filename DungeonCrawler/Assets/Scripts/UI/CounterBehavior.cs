using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBehavior : MonoBehaviour
{

    private int clickCount = 0;
    public IntData clickCountData;

    private void Start()
    {
        // Ensure the click count data is initialized properly
        UpdateClickCountData();
    }

    public void IncrementClickCount()
    {
        // Increment the click count
        clickCount++;

        // Update the click count data
        UpdateClickCountData();
    }

    private void UpdateClickCountData()
    {
        // Update the IntData with the current click count
        clickCountData.SetValue(clickCount);
    }

}
