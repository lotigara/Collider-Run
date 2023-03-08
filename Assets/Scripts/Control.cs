using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Joystick joystick;
    public ControlType controlType;
    public float speed = 1f;
    public float mobileSpeed;
    private Vector3 mouse;
    public Rigidbody2D rb;
    private Vector3 pos;
    public enum ControlType {PC, Android}
    void Start()
    {
        mouse = Input.mousePosition;
        if (controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (controlType == ControlType.PC)
        {
            Vector3 screenMousePosition = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(pos.y, pos.x));
            rb.velocity = pos * speed;
        }
        else if (controlType == ControlType.Android)
        {
            pos = new Vector3(joystick.Horizontal, joystick.Vertical);
            rb.velocity = pos * mobileSpeed;
        }
    }
}
