using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public GameObject gun;
    public GameObject shootButton;
    public GameObject decorativeGun;
    private Control player;
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == decorativeGun)
        {
            Destroy(decorativeGun);
            gun.SetActive(true);
            shootButton.SetActive(true);
        }
    }

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
    }
}
