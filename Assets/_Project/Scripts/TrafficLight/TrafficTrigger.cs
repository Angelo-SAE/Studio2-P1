using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TrafficLightManager;

public class TrafficTrigger : MonoBehaviour
{

    TrafficLightManager trafficLightManager;
    private void Start()
    {
        trafficLightManager = GetComponentInParent<TrafficLightManager>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && trafficLightManager.currentState == LightState.Red)
        {
            TimeTracker.currentTime += 10f;
            Debug.Log("You ran a red light!");
        }
        if (other.CompareTag("Player") && trafficLightManager.currentState == LightState.Green)
        {
            TimeTracker.currentTime -= 5f;
            Debug.Log("You obeyed the law");
        }
    }
}
