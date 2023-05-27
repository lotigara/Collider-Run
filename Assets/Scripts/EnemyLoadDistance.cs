using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoadDistance : MonoBehaviour
{
    private GameObject cam;
    private Collider2D ldt; // дистанция прогрузки
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera");
        ldt = GetComponent<Collider2D>();
        // задаю параметр коллайдера size на разрешение окна приложения (screen.width и screen.height), умножая на размер камеры
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Scaner2D>().enabled = true;
        }
    }
}
