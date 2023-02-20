using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Collider2D col2D;
    [SerializeField] Control control;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] CameraMove cameraMove;
    [SerializeField] MenuOpen menuOpen;
    public void Start()
    {
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        //GameObject go = GameObject.Find("MenuOpener");
        //MenuOpen menuOpen = go.GetComponent<MenuOpen>();
        //bool isLevelFinish = menuOpen.isLevelFinished;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
        if (col.transform.CompareTag("Finish"))
        {
            menuOpen.isLevelFinished = true;
            menu.SetActive(true);
            col2D.enabled = false;
            control.enabled = false;
            spriteRender.enabled = false;
            cameraMove.enabled = false;
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
