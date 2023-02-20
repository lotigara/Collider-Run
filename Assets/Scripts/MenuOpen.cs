using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] KeyCode key;
    [SerializeField] Collider2D col2D;
    [SerializeField] Control control;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] CameraMove cameraMove;
    public bool isLevelFinished;
    public bool isMenuOpen;

    public void Start()
    {
        levelMenu.SetActive(false);
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
                    menu.SetActive(true);
                    col2D.enabled = false;
                    control.enabled = false;
                    spriteRender.enabled = false;
                    cameraMove.enabled = false;
                    isMenuOpen = true;
                }
            }
            else
            {
                if (Input.GetKeyUp(key))
                {
                    menu.SetActive(false);
                    col2D.enabled = true;
                    control.enabled = true;
                    spriteRender.enabled = true;
                    cameraMove.enabled = true;
                    isMenuOpen = false;
                }
            }
        }
    }
}
