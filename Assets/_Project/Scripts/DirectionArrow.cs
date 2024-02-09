using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{

    void Update()
    {
        FindDirection();
    }

    private void FindDirection()
    {
      if(IceCream.hasIceCream)
      {
        transform.LookAt(IceCream.dropOffPoint);
      } else {
        transform.LookAt(IceCream.iceCreamPoint);
      }

    }
}
