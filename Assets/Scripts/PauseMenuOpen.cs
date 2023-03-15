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
    [HideInInspector] public bool isLevelFinished;
    bool isMenuOpen;

    public void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
        col2D = GameObject.Find("Player").GetComponent<Collider2D>();
        spriteRender = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        //menu = GameObject.Find("PausePanel");
        levelMenu = GameObject.Find("LevelsPanel");
        levelMenu.SetActive(false);
        isMenuOpen = false;
    }
    public void GameOpenMenu(GameObject openMenu)
    {
        openMenu.SetActive(true);
        col2D.enabled = false;
        control.enabled = false;
        spriteRender.enabled = false;
        cameraMove.enabled = false;
        isMenuOpen = true;
    }
    public void GameCloseMenu(GameObject closeMenu)
    {
        closeMenu.SetActive(false);
        col2D.enabled = true;
        control.enabled = true;
        spriteRender.enabled = true;
        cameraMove.enabled = true;
        isMenuOpen = false;
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
