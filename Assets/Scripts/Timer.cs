using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float StopWatch;
    public float stopWatch{get{return StopWatch;}set{StopWatch = value;}}

    public void StartTimer()
    {
        StopWatch += Time.deltaTime;
    }

    public void StopTimer()
    {
        StopWatch = 0;
    }
}
