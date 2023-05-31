using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
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
        GetComponent<Gun>().Shoot();
    }

    public bool isDefeated()
    {
        if (gameObject.activeSelf == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
