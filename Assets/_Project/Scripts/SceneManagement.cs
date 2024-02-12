using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public void LoadScene(string scene)
  {
    PauseMenu.UnPauseGame();
    SceneManager.LoadScene(scene);
  }

  public void Exit()
  {
    Application.Quit();
  }
}
