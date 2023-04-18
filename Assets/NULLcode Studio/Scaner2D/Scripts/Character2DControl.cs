using System.Collections;
using UnityEngine;

public class Character2DControl : MonoBehaviour
{
	private Vector3 direction;
	private int layerMask;
	private Rigidbody2D body;

	void Awake() 
	{
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
		layerMask = 1 << gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
	}
}
