using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoadDistance : MonoBehaviour
{
    private ArrayList scaner2d;
    public ArrayList enemies;
    private void Start()
    {
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        foreach (GameObject enemy in enemies)
        {
            scaner2d.Add(enemy.GetComponent<Scaner2D>());
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (enemies.Contains(col.gameObject))
        {
            col.gameObject.GetComponent<Scaner2D>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (enemies.Contains(col.gameObject))
        {
            col.gameObject.GetComponent<Scaner2D>().enabled = false;
        }
    }
}
