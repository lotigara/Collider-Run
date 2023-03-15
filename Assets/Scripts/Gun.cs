using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private CameraShake cameraShake;
    private Control player;

    public void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
    }

    void Update()
    {
        //if (player.controlType == Control.ControlType.PC)
        //{
            //GetGun.shootButton.SetActive(false);
        //}
            
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && player.controlType == Control.ControlType.PC)
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        timeBtwShots = startTimeBtwShots;
        cameraShake.Shake();
    }
}
