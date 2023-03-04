using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presses : MonoBehaviour
{
    [SerializeField] int pressPerSecond;
    [SerializeField] Transform[] presses;

    void Start()
    {
        InvokeRepeating("randomNumber", 0, pressPerSecond);
    }
    public void Pressing()
    {
        
    }
}
