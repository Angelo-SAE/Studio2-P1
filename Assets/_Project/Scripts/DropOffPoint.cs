using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPoint : MonoBehaviour
{
  private void OnTriggerEnter(Collider col)
  {
    if(IceCream.hasIceCream)
    {
      IceCream.iceCreamCount++;
      IceCream.hasIceCream = false;
      Destroy(gameObject);
    }
  }
}
