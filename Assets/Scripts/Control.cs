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
        //Debug.Log(Input.mousePosition);
        //transform.LookAt(transform, screenMousePosition);
        //transform.position = Vector2.MoveTowards(transform.position, screenMousePosition, speed * Time.deltaTime);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(pos.y, pos.x));
        //var dir = (screenMousePosition - transform.position).normalized;
        rb.velocity = pos * speed;
        //rb.SetRotation(screenMousePosition.x- screenMousePosition.x);
        //rb.rotation(new Vector3(0, 0, 0));
        //transform.LookAt(new Vector3(0,0,dir.x));
        //var move = new Vector2(rb.position.x, rb.position.y);
        //var mouseMove = new Vector2(screenMousePosition.x, screenMousePosition.y);
        //move = Vector2.MoveTowards(move, mouseMove, speed * Time.deltaTime);
        //rb.velocity = move;
    }
}
