using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarassment : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int speed = 5;
    public bool isOld;
    Transform viewDistance;

    void Start()
    {
        viewDistance = transform.Find("ViewDistance");
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (isOld == false)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if
                (
                    viewDistance.gameObject.GetComponent<Collider2D>().IsTouching
                    (
                        col.gameObject.GetComponent<Collider2D>()
                    )
                )
                {
                    Vector3 direction = player.position - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    direction.Normalize();
                    movement = direction;
                    transform.rotation = Quaternion.Euler
                    (
                        transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2
                        (
                            player.position.y - transform.position.y, player.position.x - transform.position.x
                        )
                        * Mathf.Rad2Deg
                    );

                };
            }
        }
        else
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
            transform.rotation = Quaternion.Euler
            (
                transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2
                (
                    player.position.y - transform.position.y, player.position.x - transform.position.x
                )
                * Mathf.Rad2Deg
            );
        }
    }
    private void FixedUpdate()
    {
        MoveChar(movement);
    }
    private void MoveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
