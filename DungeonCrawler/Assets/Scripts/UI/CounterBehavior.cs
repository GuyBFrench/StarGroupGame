using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBehavior : MonoBehaviour
{
        public IntData loadRandomSceneCountData; // Reference to the IntData script for counting
    
        public void CountLoadRandomScene()
        {
            if (loadRandomSceneCountData != null)
            {
                loadRandomSceneCountData.UpdateValue(1);
            }
        }
   }
