using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsUI : MonoBehaviour
{
  [SerializeField] private GameObject MenuHolder;

   void Update()
   {
     if(Input.GetButtonDown("OpenControls"))
     {
       if(MenuHolder.activeInHierarchy)
       {
         MenuHolder.SetActive(false);
       } else {
         MenuHolder.SetActive(true);
       }
     }
   }
}
