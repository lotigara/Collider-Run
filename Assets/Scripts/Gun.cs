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
    private Boss boss;
    private CameraShake cameraShake;
    private Control player;
    private float nextActionTime = 0f;
    private enum GunType { Player, Spawner, Enemy }
    [SerializeField] private GunType gunType;
    [SerializeField] bool isSpawner;

    public void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        if (player.controlType == Control.ControlType.PC)
        {
            shootButton.SetActive(false);
        }
        if (player.controlType == Control.ControlType.Android)
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
        if (gunType != GunType.Spawner && gunType != GunType.Enemy)
        {
            cameraShake.Shake();
        }
        Instantiate(bullet, shotPoint.position, transform.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}
