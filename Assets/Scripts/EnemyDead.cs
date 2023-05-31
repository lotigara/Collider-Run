using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public float health = 1;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
