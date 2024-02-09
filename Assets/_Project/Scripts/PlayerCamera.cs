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
        transform.localPosition = new Vector3(0f, 3f, 2f);
        transform.Rotate(60f, 180f, 0f, Space.Self);
      }
      if(Input.GetButtonUp("LookBack"))
      {
        transform.localPosition = new Vector3(0f, 4f, -3f);
        transform.Rotate(60f, 180f, 0f, Space.Self);
      }
    }
}
