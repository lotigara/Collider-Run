using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pauseMenu;
    GameObject player;
    [SerializeField] CameraMove cameraMove;
    [SerializeField] PauseMenuOpen menuOpen;
    public int nextLevel;
    int level;
    public void Start()
    {
        Debug.Log(level);
        level = PlayerPrefs.GetInt("level");
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        player = gameObject;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Finish"))
        {
            if (level > nextLevel)
            {
                PlayerPrefs.SetInt("level", level);
            }
            else if (level <= nextLevel)
            {
                PlayerPrefs.SetInt("level", nextLevel);
            }
            menuOpen.isLevelFinished = true;
            menu.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
