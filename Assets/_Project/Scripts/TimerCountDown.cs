using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{

    [SerializeField] private float timerSpeed, time, increaseAmount;
    private AudioSource timerTick;

    void Start()
    {
      timerTick = GetComponent<AudioSource>();
    }

    void Update()
    {
        Counter();
        SetTimer();
        TimerAudioSpeed();
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

    private void TimerAudioSpeed()
    {
      var pitchIncrease = Mathf.Lerp(0f,0.2f,TimeTracker.currentTime/100);
      timerTick.pitch = pitchIncrease + (IceCream.iceCreamCount/50f) + 1;

      if(PauseMenu.paused)
      {
        timerTick.mute = true;
      } else {
        timerTick.mute = false;
      }
    }

    public void Restart()
    {
      TimeTracker.currentTime = 0f;
      TimeTracker.isDead = false;
      IceCream.iceCreamCount = 0;
      IceCream.hasIceCream = false;
    }

}
