using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPoint : MonoBehaviour
{

  [SerializeField] private float timeReduction;

  void Awake()
  {
    IceCream.dropOffPoint = transform.position;
  }

  private void OnTriggerEnter(Collider col)
  {
    if(IceCream.hasIceCream && col.gameObject.CompareTag("Player"))
    {
      IceCream.iceCreamCount++;
      IceCream.deliveryComplete = true;
      TimeTracker.ReduceTime(timeReduction);
      IceCream.hasIceCream = false;
      Destroy(gameObject);
    }
  }
}
