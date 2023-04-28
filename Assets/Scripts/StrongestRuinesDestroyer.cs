using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongestRuinesDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BassDestroyable")) 
        {
            Destroy(col.gameObject);
        }
    }
}
