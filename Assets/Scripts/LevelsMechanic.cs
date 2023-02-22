using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMechanic : MonoBehaviour
{
    public int level;
    [SerializeField] Button[] levelButton;

    public void Start()
    {
        level = PlayerPrefs.GetInt("level");
        //level = 6;
        Debug.Log(level);
        for (int i=0; i < level; i++)
        {
            levelButton[i].interactable = true;
        }
       
    }

    public void ResetSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}
