using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour 
{
    LevelsMechanic levelsMechanic;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitScene(int level)
    {
        if (levelsMechanic.level < level)
        {
            levelsMechanic.level = level;
            PlayerPrefs.SetInt("level", level);
        }

    }
    public void Exit()
    {
        Application.Quit();
    }
}
