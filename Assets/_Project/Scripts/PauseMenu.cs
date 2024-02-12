using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;

    private GameObject pauseMenu;

    void Start()
    {
      pauseMenu = gameObject.transform.GetChild(0).gameObject;
    }


    void Update()
    {
      if(Input.GetButtonDown("Pause") && !paused)
      {
        PauseGame();
        pauseMenu.SetActive(true);
      } else if(Input.GetButtonDown("Pause") && paused)
      {
        UnPauseGame();
        pauseMenu.SetActive(false);
      }
    }

    public static void PauseGame()
    {
      Time.timeScale = 0f;
      paused = true;
    }

    public static void UnPauseGame()
    {
      Time.timeScale = 1f;
      paused = false;
    }
}
