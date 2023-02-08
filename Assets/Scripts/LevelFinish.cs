using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] Canvas menu;
    [SerializeField] GameObject player;
    [SerializeField] Collider2D col2D;
    [SerializeField] Control control;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] CameraMove cameraMove;
    public void Start()
    {
        menu.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Finish"))
        {
            menu.enabled = true;
            col2D.enabled = false;
            control.enabled = false;
            spriteRender.enabled = false;
            cameraMove.enabled = false;
        }
        else
        {
            menu.enabled = false;
        }
    }
}
