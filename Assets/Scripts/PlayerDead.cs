using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathParticle;
    private Boss boss;
    private int keys;
    public float health = 1;
    private float timeLeft = 5;
    /*private float nextActionTime = 0.0f;
    private float period = 1.0f;*/

    public void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        keys = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy") || col.transform.CompareTag("Respawn") || col.transform.CompareTag("LaserDoor"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (col.transform.CompareTag("Key"))
        {
            Destroy(col.gameObject);
            keys += 1;
            Debug.Log(keys);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Vault")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (keys == 6)
                {
                    PlayerPrefs.SetInt("custom", 1);
                    Debug.Log("Vault is open! Keys: " + keys);
                }
                if (keys >= 7 )
                {
                    if (!! PlayerPrefs.GetString("clothes").Contains("secret/"))
                    {
                        PlayerPrefs.SetString("clothes", PlayerPrefs.GetString("clothes") + "secret/");
                        Debug.Log(PlayerPrefs.GetString("clothes"));
                    }
                    Debug.Log("You are not a cheater! You will get no ban on my Discord server!");
                }
            }
        }

        if (col.gameObject.tag == "Switcher")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                col.gameObject.GetComponent<Animator>().SetTrigger("activate");
                GameObject.FindGameObjectWithTag("LaserDoor").SetActive(false);
                GameObject.FindGameObjectWithTag("LaserParticle").SetActive(false);
            }
        }
        if (col.gameObject.tag == "BossTrigger")
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                boss.gameObject.SetActive(true);
                boss.Aim(transform);
            }
            /*boss.Appear(10);
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                for (int i = 10; i > 0; i --)
                {
                    GameObject.FindGameObjectWithTag("ReadyText").GetComponent<Text>().text = $"{i}";
                }
            }*/
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

