using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
  [SerializeField] private float waterSpeed, increaseSpeed;
  private bool flooding;

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.K))
    {
      StartFlooding();
    }
  }

    public void StartFlooding()
    {
      if(!flooding)
      {
        StartCoroutine(Flood());
        flooding = true;
      }
    }

    private IEnumerator Flood()
    {
      while(true)
      {
        yield return new WaitForSeconds(increaseSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y + waterSpeed, transform.position.z);
      }

    }
}
