using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamPickUp : MonoBehaviour
{
    void Awake()
    {
      IceCream.iceCreamPoint = transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.CompareTag("Player"))
      {
        IceCream.hasIceCream = true;
        Destroy(gameObject);
      }
    }
}
