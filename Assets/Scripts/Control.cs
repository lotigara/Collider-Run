using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Joystick joystick;
    public ControlType controlType;
    public float offset;
    public float speed = 1f;
    public float mobileSpeed = 60;
    private Vector3 mouse;
    public Rigidbody2D rb;
    private float rotZ;
    private Vector3 difference;
    private Vector3 pos;
    
    public enum ControlType
    {
        PC = 0,
        Android = 1
    }
    void Start()
    {
        mouse = Input.mousePosition;
        if (controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }
        /*if (PlayerPrefs.GetInt("platform") == 0)
        {
            controlType = ControlType.PC;

        }
        else if (PlayerPrefs.GetInt("platform") == 1)
        {
            controlType = ControlType.Android;
        }*/
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
        else if (controlType == ControlType.Android && Mathf.Abs(joystick.Horizontal) > 0.001f || Math.Abs(joystick.Vertical) > 0.001f)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            pos = new Vector3(joystick.Horizontal, joystick.Vertical);
            rb.velocity = pos * mobileSpeed;
        }
    }
}
