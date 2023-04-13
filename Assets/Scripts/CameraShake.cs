using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator cam;

    public void Shake()
    {
        cam.SetTrigger("shake");
    }
}
