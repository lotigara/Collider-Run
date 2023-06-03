using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Aim(Transform player)
    {
        transform.rotation = Quaternion.Euler
        (
            transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2
            (
                player.position.y - transform.position.y, player.position.x - transform.position.x
            )
            * Mathf.Rad2Deg
        );
        if (GetComponent<Gun>().patrons > 0)
        {
            GetComponent<Gun>().Shoot();
        }
    }

    public void Fight()
    {
        if (GetComponent<Gun>().patrons > 0)
        {
            Aim(player);
        }
        else if (GetComponent<Gun>().patrons <= 0)
        {
            GetComponent<PlayerHarassment>().enabled = true;
            if (GetComponent<EnemyDead>().health <= 10)
            {
                GetComponent<PlayerHarassment>().enabled = false;
                GetComponent<Gun>().patrons += 15;
            }
        }
    }
}
