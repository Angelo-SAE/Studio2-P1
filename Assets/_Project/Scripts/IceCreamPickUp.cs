using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
      IceCream.hasIceCream = true;
      Destroy(gameObject);
    }
}
