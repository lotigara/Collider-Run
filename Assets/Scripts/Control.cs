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
    public Text platform;
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
        //платформы
        /*if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            controlType = ControlType.Android;
            PlayerPrefs.SetInt("platform", ((int)controlType));
        }
        else
        {
            controlType = ControlType.Android;
            PlayerPrefs.SetInt("platform", ((int)controlType));
        }
        Debug.Log(((int)controlType));
        */
        if (PlayerPrefs.GetInt("platform") == 0)
        {
            platform.text = "Change Platform. Current platform: PC";
            controlType = ControlType.PC;
            
        }
        else if (PlayerPrefs.GetInt("platform") == 1)
        {
            platform.text = "Change Platform. Current platform: Mobile";
            controlType = ControlType.Android;
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
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            pos = new Vector3(joystick.Horizontal, joystick.Vertical);
            rb.velocity = pos * mobileSpeed;
        }
    }

    public void ChangePlatform()
    {
        if (PlayerPrefs.GetInt("platform") == 0)
        {
            controlType = ControlType.Android;
            PlayerPrefs.SetInt("platform", 1);
            platform.text = "Change Platform. Current platform: Mobile";
        }
        else if (PlayerPrefs.GetInt("platform") == 1)
        {
            controlType = ControlType.PC;
            PlayerPrefs.SetInt("platform", 0);
            platform.text = "Change Platform. Current platform: PC";
        }
        
        //PlayerPrefs.DeleteKey("platform");
    }
}
