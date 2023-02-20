using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMechanic : MonoBehaviour
{
    public int level;
    public int convertedLevel;
    [SerializeField] Button[] levelButton;

    public void Start()
    {
        convertedLevel = level - 1;
        level = PlayerPrefs.GetInt("level", 0);
        levelButton[level - 1].interactable = true;
    }

    public void ResetSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}
