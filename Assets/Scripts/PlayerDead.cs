using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathParticle;
    private int keys;

    public void Start()
    {
        keys = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy") || col.transform.CompareTag("Respawn"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else col.transform.CompareTag("Key");
        {
            Destroy(col.gameObject);
            keys += 1;
            Debug.Log(keys);
        };
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Vault")
        {
            if (keys >= 6)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    keys = 0;
                    PlayerPrefs.SetInt("custom", 1);
                    Debug.Log("Vault is open! Keys: " + keys);
                }
            }
        }
    }
}

