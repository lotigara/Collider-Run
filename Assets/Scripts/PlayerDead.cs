using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathParticle;
    public GameObject beforeLaser;
    public GameObject beforeLaserParticle;
    public GameObject beforeSwitcher;
    public GameObject afterLaser;
    public GameObject afterLaserParticle;
    public GameObject finishLaser;
    public GameObject finishLaserParticle;
    public GameObject afterSwitcher;
    //public GameObject deathPanel;
    public Boss boss;
    private int keys;
    public float health = 1;

    public void Start()
    {
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
        else if (col.transform.CompareTag("Speed"))
        {
            Destroy(col.gameObject);
            GetComponent<Control>().speed = GetComponent<Control>().speed * 2;
            GetComponent<Control>().mobileSpeed = GetComponent<Control>().mobileSpeed * 2;
        }
        else if (col.transform.CompareTag("Health"))
        {
            Destroy(col.gameObject);
            health += 4;
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
                    Debug.Log("You are not a cheater! You will get no ban on my Discord server!");
                }
            }
        }

        if (col.gameObject == beforeSwitcher)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                boss.gameObject.SetActive(true);
                col.gameObject.GetComponent<Animator>().SetTrigger("activate");
                beforeLaser.SetActive(false);
                beforeLaserParticle.SetActive(false);
            }
        }
        if (col.gameObject == afterSwitcher)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                col.gameObject.GetComponent<Animator>().SetTrigger("activate");
                finishLaser.SetActive(false);
                finishLaserParticle.SetActive(false);
                beforeLaser.SetActive(false);
                beforeLaserParticle.SetActive(false);
            }
        }
        if (col.gameObject.tag == "BossTrigger")
        {
            boss.Fight();
            beforeLaser.SetActive(true);
            beforeLaserParticle.SetActive(true);
        }
        if (GameObject.FindGameObjectWithTag("Boss") == null)
        {
            afterLaser.SetActive(false);
            afterLaserParticle.SetActive(false);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

