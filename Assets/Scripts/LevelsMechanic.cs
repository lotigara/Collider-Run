using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMechanic : MonoBehaviour
{
    public int level = 1;
    public GameObject[] closedLevel;

    private void Start()
    {
        level = PlayerPrefs.GetInt("level", level);
        for (int i = 0; 1 < level; i++)
        {
            closedLevel[i].SetActive(false);
        }
    }
}
