using System.Collections;
using System.Collections.Generic;
using KMK;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    
    private IEnumerator hitStopRoutine;
    
    
    public void ChangeTimeScale(float duration, float timeScale)
    {
        if (hitStopRoutine != null)
        {
            StopCoroutine(hitStopRoutine);
        }
        hitStopRoutine = WaitChangeTimeScale(duration, timeScale);
        StartCoroutine(hitStopRoutine);
    }
    
    IEnumerator WaitChangeTimeScale(float duration, float timeScale)
    {
        Time.timeScale = timeScale;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
    }
}
