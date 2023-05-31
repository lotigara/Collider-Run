using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuOpen : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private KeyCode key = KeyCode.Escape;
    private GameObject player;
    public bool isLevelFinished;
    bool isMenuOpen;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isMenuOpen = false;
    }
    public void GameOpenMenu(GameObject openMenu)
    {
        isMenuOpen = true;
        openMenu.SetActive(true);
        player.SetActive(false);
    }
    public void GameCloseMenu(GameObject closeMenu)
    {
        isMenuOpen = false;
        closeMenu.SetActive(false);
        player.SetActive(true);
    }
    public void OpenMenu(GameObject openMenu)
    {
        isMenuOpen = true;
        openMenu.SetActive(true);
    }
    public void CloseMenu(GameObject closeMenu)
    {
        isMenuOpen = false;
        closeMenu.SetActive(false);
    }
    public void Update()
    {
        if(isLevelFinished == false)
        {
            if (isMenuOpen == false)
            {
                if (Input.GetKeyUp(key))
                {
                    GameOpenMenu(menu);
                }
            }
            else
            {
                if (Input.GetKeyUp(key))
                {
                    GameCloseMenu(menu);
                }
            }
        }
    }
}
