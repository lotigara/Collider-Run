using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Respawn"))
        {
            transform.position = spawnPoint.position;
        }
    }
}
