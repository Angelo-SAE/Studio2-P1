using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverMenu : MonoBehaviour
{

    private GameObject deadMenu;

    void Start()
    {
      deadMenu = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        CheckDead();
    }

    private void CheckDead()
    {
      if(TimeTracker.isDead)
      {
        deadMenu.SetActive(true);
      } else {
        deadMenu.SetActive(false);
      }
    }
}
