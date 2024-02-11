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
            //insert player punishment logic (flat time deduction or % deduction)
            //consider adding logic that prevents the player from getting penalised multiple times from one red light instance

            Debug.Log("You ran a red light!");
        }
    }
}
