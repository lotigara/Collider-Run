using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLoadDistance : MonoBehaviour
{
    private Camera cam; // камера
    private BoxCollider2D ldt; // дистанция прогрузки
    private Vector2 aspectRatio;
    private void Start()
    {
        // задаю значения переменных
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        ldt = this.gameObject.GetComponent<BoxCollider2D>();
        aspectRatio = Nod(new Vector2(Screen.currentResolution.width, Screen.currentResolution.height));

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

    private static Vector2 Nod(Vector2 fraction)
    {
        // числитель = fraction.x, знаменатель = fraction.y
        fraction.x = Math.Abs(fraction.x);
        fraction.y = Math.Abs(fraction.y);
        while (fraction.x != 0 && fraction.y != 0)
        {
            if (fraction.x % fraction.y > 0)
            {
                var temp = fraction.x;
                fraction.x = fraction.y;
                fraction.y = temp % fraction.y;
            }
            else break;
        }
        if (fraction.y != 0 && fraction.x != 0) return fraction;
        return new Vector2(0, 0);
    }
}
