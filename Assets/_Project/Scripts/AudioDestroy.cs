using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestroy : MonoBehaviour
{
    [SerializeField] private float waitTime;
    
    void Start()
    {
      StartCoroutine(DestroyAudio());
    }

    private IEnumerator DestroyAudio()
    {
      yield return new WaitForSeconds(waitTime);
      Destroy(gameObject);
    }
}
