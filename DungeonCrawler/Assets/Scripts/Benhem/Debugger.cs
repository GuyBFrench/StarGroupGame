using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Debugger : ScriptableObject
{
    public void OnDebugger(string obj)
    {
        Debug.Log(obj);
    }
    
    public void OnDebugger(int obj)
    {
        Debug.Log(obj);
    }
    
    public void OnDebugger(float obj)
    {
        Debug.Log(obj);
    }
    
    public void OnDebugger(object obj)
    {
        Debug.Log(obj);
    }
}
