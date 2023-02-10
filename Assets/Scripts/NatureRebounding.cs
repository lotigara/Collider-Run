using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureRebounding : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D rb;
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "BouncePad")
        {
            rb.velocity = transform.up * speed;
        }

    }
}
