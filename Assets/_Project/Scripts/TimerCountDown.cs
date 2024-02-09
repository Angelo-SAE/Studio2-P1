using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{

    [SerializeField] private float timerSpeed, time, increaseAmount;

    void Update()
    {
        Counter();
        SetTimer();
    }

    private void Counter()
    {
      time += Time.deltaTime;
      if(time >= timerSpeed)
      {
        TimeTracker.currentTime += increaseAmount;
        time = 0;
      }
    }

    private void SetTimer()
    {
      GetComponent<Image>().fillAmount = TimeTracker.currentTime/100;
    }

}
