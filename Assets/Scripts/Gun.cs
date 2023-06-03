using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private float timeSinceStart = 0;
    public GameObject shootButton;
    //private Boss boss;
    private CameraShake cameraShake;
    private Control player;
    private float nextActionTime = 0f;
    public int patrons;
    private enum GunType { Player, Spawner, Enemy }
    [SerializeField] private GunType gunType;

    public void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        if (player.controlType == Control.ControlType.PC && gunType == GunType.Player)
        {
            shootButton.SetActive(false);
        }
        if (player.controlType == Control.ControlType.Android && gunType == GunType.Player)
        {
            shootButton.SetActive(true);
        }
    }

    void Update()
    {
        if (gunType == GunType.Player)
        {
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
        else if (gunType == GunType.Spawner && timeSinceStart > nextActionTime)
        {
            nextActionTime += timeBtwShots;
            Shoot();
        }
        timeSinceStart += Time.deltaTime;
    }

    public void Shoot()
    {
        
        if (gunType == GunType.Enemy)
        {
            patrons -= 1;
        }
        else if (gunType != GunType.Spawner && gunType != GunType.Enemy)
        {
            cameraShake.Shake();
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
