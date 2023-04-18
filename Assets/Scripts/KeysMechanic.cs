using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysMechanic : MonoBehaviour
{
    private int keys;
    void Start()
    {
        keys = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Key"))
        {
            keys++;
        }
        else if (col.gameObject.CompareTag("Vault"))
        {
            if (keys == 6)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    keys = 0;
                    PlayerPrefs.SetInt("custom", 1);
                }
            }
        }
    }
}
