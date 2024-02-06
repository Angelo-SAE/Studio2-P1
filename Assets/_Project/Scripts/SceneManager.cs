using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
      Application.Quit();
    }
}
