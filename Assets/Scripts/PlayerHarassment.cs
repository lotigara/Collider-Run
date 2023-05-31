using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarassment : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
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
        MoveChar(movement);
    }

    private void MoveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
