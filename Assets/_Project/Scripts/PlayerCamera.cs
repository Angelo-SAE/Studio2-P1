using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
      if(Input.GetButtonDown("LookBack"))
      {
        transform.position = new Vector3(0f, 2f, 3f);
        transform.Rotate(0f, 180f, 0f, Space.Self);
      }
      if(Input.GetButtonUp("LookBack"))
      {
        transform.position = new Vector3(0f, 2f, -5f);
        transform.Rotate(0f, 180f, 0f, Space.Self);
      }
    }
}
