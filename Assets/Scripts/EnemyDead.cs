﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Respawn"))
        {
            Destroy(this.gameObject);
        }
    }
}
