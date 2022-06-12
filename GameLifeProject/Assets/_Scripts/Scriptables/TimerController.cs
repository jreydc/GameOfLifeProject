using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Timer", fileName = "TimerController")]
public class TimerController : ScriptableObject
{
    public Timer timerInstance;

    public void TimerInitializations(){
        timerInstance.time = 0f;
        timerInstance.timerSpeed = 0.1f;
        timerInstance.time_scale = 1f;
    }
}
