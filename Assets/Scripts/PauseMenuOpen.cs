using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuOpen : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [HideInInspector] public GameObject levelMenu;
    [HideInInspector] public KeyCode key = KeyCode.Escape;
    [HideInInspector] public Collider2D col2D;
    [HideInInspector] public Control control;
    [HideInInspector] public SpriteRenderer spriteRender;
    [HideInInspector] public CameraMove cameraMove;
    [HideInInspector] public GameObject player;
    [HideInInspector] public bool isLevelFinished;
    bool isMenuOpen;

    public void Start()
    {
        GameCloseMenu(menu);
        player = GameObject.FindGameObjectWithTag("Player");
        isMenuOpen = false;
    }
    public void GameOpenMenu(GameObject openMenu)
    {
        openMenu.SetActive(true);
        player.SetActive(false);
    }
    public void GameCloseMenu(GameObject closeMenu)
    {
        closeMenu.SetActive(false);
        player.SetActive(true);
    }
    public void OpenMenu(GameObject openMenu)
    {
        openMenu.SetActive(true);
    }
    public void CloseMenu(GameObject closeMenu)
    {
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
