using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator cam;

    public void Start()
    {
        cam = gameObject.GetComponent<Animator>();
    }

    public void Shake()
    {
        cam.SetTrigger("shake");
    }
}
