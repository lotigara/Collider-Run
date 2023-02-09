using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Collider2D col2D;
    [SerializeField] Control control;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] CameraMove cameraMove;
    public void Start()
    {
        menu.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Finish"))
        {
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
    private void Update()
    {

    }
}
