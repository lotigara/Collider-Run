using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public GameObject gun;
    public GameObject decorativeGun;
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == decorativeGun)
        {
            Destroy(decorativeGun);
            gun.SetActive(true);
        }
    }
}
