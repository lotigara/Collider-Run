using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;
    private Vector3 mouse;
    public Rigidbody2D rb;
    void Start()
    {
        mouse = Input.mousePosition;
    }

    void FixedUpdate()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        //transform.LookAt(transform, screenMousePosition);
        //transform.position = Vector2.MoveTowards(transform.position, screenMousePosition, speed * Time.deltaTime);
        var dir = (screenMousePosition - transform.position).normalized;
        rb.velocity = dir * speed;

        //var move = new Vector2(rb.position.x, rb.position.y);
        //var mouseMove = new Vector2(screenMousePosition.x, screenMousePosition.y);
        //move = Vector2.MoveTowards(move, mouseMove, speed * Time.deltaTime);
        //rb.velocity = move;
    }
}
