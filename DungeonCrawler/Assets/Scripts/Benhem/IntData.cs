using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData1 : ScriptableObject
{
    public UnityEvent maxValueEvent, minValueEvent;
    public int value;

    public void SetValue(int num)
    {
        value = num;
    }

    public void CompareValue(IntData1 obj)
    {
        if (value >= obj.value)
        {
            
        }
        else
        {
            value = obj.value;
        }
    }
    
    public void SetValue(IntData1 obj)
    {
        value = obj.value;
    }
    
    public void UpdateValue(int num)
    {
        value += num;
    }
    
    public void CheckMinValue(int minValue)
    {
        if (!(value <= minValue)) return;
        minValueEvent.Invoke();
        value = minValue;
    }

    public void CheckMaxValue(int maxValue)
    {
        if (!(value >= maxValue)) return;
        maxValueEvent.Invoke();
        value = maxValue;
    }
    
}