using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    public enum LightState { Green, Yellow, Red }
    public LightState currentState;

    public float greenLightMinDuration = 7f;
    public float greenLightMaxDuration = 10f;
    public float yellowLightDuration = 2f;
    public float redLightDuration = 5f;

    public Light bulbLight;
    public Renderer bulbRenderer;

    private float timer;

    void Start()
    {
        
        currentState = LightState.Green;
        timer = Random.Range(greenLightMinDuration, greenLightMaxDuration);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        switch (currentState)
        {
            case LightState.Green:
                if (timer <= 0)
                {
                    ChangeState(LightState.Yellow);
                    timer = yellowLightDuration;
                }
                break;
            case LightState.Yellow:
                if (timer <= 0)
                {
                    ChangeState(LightState.Red);
                    timer = redLightDuration;
                }
                break;
            case LightState.Red:
                if (timer <= 0)
                {
                    ChangeState(LightState.Green);
                    timer = Random.Range(greenLightMinDuration, greenLightMaxDuration);
                }
                break;
        }
    }

    void ChangeState(LightState newState)
    {
        currentState = newState;


        switch (currentState)
        {
            case LightState.Green:
                bulbRenderer.material.color = Color.green;
                bulbLight.color = Color.green;
                break;
            case LightState.Yellow:
                bulbRenderer.material.color = Color.yellow;
                bulbLight.color = Color.yellow;
                break;
            case LightState.Red:
                bulbRenderer.material.color = Color.red;
                bulbLight.color = Color.red;
                break;
        }
    }

    
}
