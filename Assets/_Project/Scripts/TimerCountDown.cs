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
      if(time >= timerSpeed/((IceCream.iceCreamCount/20f)+ 1f))
      {
        TimeTracker.currentTime += increaseAmount;
        time = 0f;
      }
      if(TimeTracker.currentTime >= 100f)
      {
        TimeTracker.isDead = true;
      }
    }

    private void SetTimer()
    {
      GetComponent<Image>().fillAmount = TimeTracker.currentTime/100f;
    }

    public void Restart()
    {
      TimeTracker.currentTime = 0f;
      TimeTracker.isDead = false;
      IceCream.iceCreamCount = 0;
      IceCream.hasIceCream = false;
    }

}
