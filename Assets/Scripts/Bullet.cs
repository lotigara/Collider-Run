using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;

    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            if(hitInfo.collider.CompareTag("Destroyable"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            Destroy(this.gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
