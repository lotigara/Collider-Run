using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoadDistance : MonoBehaviour
{
    private Camera cam; // камера
    private BoxCollider2D ldt; // дистанция прогрузки
    private void Start()
    {
        // задаю значения переменных
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        ldt = this.gameObject.GetComponent<BoxCollider2D>();

        // задаю параметр коллайдера Size на разрешение всего экрана (screen.width и screen.height), умножая на размер камеры (125)
        ldt.size = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height) / 125 * 3;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Scaner2D>().enabled = true; // включаю мозги врагов при коллизии прогрузки с врагами
        }
    }
}
