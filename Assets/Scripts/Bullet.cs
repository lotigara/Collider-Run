using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public float damage = 1;
    public LayerMask whatIsSolid;
    public GameObject destroyParticle;

    public void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.gameObject.GetComponent<EnemyDead>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.gameObject.GetComponent<EnemyDead>().TakeDamage(damage);
            }
            else if(hitInfo.collider.CompareTag("Destroyable"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            else if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.gameObject.GetComponent<PlayerDead>().TakeDamage(damage);
            }
            DestroyBullet();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void DestroyBullet()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
