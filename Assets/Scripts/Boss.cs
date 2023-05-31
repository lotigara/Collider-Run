using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public void Aim(Transform point)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(point.position.y - transform.position.y, point.position.x - transform.position.x) * Mathf.Rad2Deg);
        GetComponent<Gun>().Shoot();
    }
}
