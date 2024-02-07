using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControls : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    public WheelCollider wheelCollider;
    private Vector3 wheelPosition;
    private Quaternion wheelRotation;
    public bool motorized, steerable;

    void Start()
    {
      wheelCollider = GetComponent<WheelCollider>();
    }

    void Update()
    {
      wheelCollider.GetWorldPose(out wheelPosition, out wheelRotation);
      wheel.transform.position = wheelPosition;
      wheel.transform.rotation = wheelRotation;
    }
}
