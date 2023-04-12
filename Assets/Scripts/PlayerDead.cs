using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathParticle;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy") || col.transform.CompareTag("Respawn"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
