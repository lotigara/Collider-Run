using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{
    public Text platform;
    private Control player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        //платформы
        /*if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            controlType = ControlType.Android;
            PlayerPrefs.SetInt("platform", 1);
        }
        else
        {
            controlType = ControlType.PC;
            PlayerPrefs.SetInt("platform", 0);
        }
        Debug.Log(((int)controlType));
        */
    }

    public void ChangePlatform()
    {
        if (PlayerPrefs.GetInt("platform") == 0)
        {
            player.controlType = Control.ControlType.Android;
            PlayerPrefs.SetInt("platform", 1);
            platform.text = "Change Platform. Current platform: Mobile";
        }
        else if (PlayerPrefs.GetInt("platform") == 1)
        {
            player.controlType = Control.ControlType.PC;
            PlayerPrefs.SetInt("platform", 0);
            platform.text = "Change Platform. Current platform: PC";
        }
    }
}
