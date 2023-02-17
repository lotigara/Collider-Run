using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] KeyCode keyOpen;
    [SerializeField] KeyCode keyClose;
    [SerializeField] Collider2D col2D;
    [SerializeField] Control control;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] CameraMove cameraMove;
    public bool isLevelFinished;

    private void Start()
    {
        levelMenu.SetActive(false);
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
            if (Input.GetKeyUp(keyOpen))
            {
                menu.SetActive(true);
                col2D.enabled = false;
                control.enabled = false;
                spriteRender.enabled = false;
                cameraMove.enabled = false;
            }
            if (Input.GetKeyUp(keyClose))
            {
                menu.SetActive(false);
                col2D.enabled = true;
                control.enabled = true;
                spriteRender.enabled = true;
                cameraMove.enabled = true;
            }
        }
    }
}
