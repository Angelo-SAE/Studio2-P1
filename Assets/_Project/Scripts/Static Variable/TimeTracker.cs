using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker
{
    public static float currentTime;

    public static void ReduceTime(float timeReduction)
    {
      currentTime = Mathf.Clamp(currentTime -= timeReduction, 0f,100f);

    }
}
