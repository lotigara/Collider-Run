using System.Collections;
using UnityEngine;

public class Scaner2D : MonoBehaviour {

	[SerializeField] private LayerMask targetMask; // маски целей
	[SerializeField] private LayerMask ignoreMask; // маски, которые нужно игнорировать (например, маска данного персонажа)
	[SerializeField] [Range(1, 300)] private int rays = 3; // число лучей по формуле (N * 2) - 1, где N - данная переменная
	[SerializeField] [Range(1, 100)] private float distance = 5; // длинна луча
	[SerializeField] [Range(0, 360)] private float angle = 20; // угол между лучами
	[SerializeField] private Transform rayPoint; // объект, из которого выпускаются лучи
	private Transform player;
	private Vector2 movement;
	private Rigidbody2D rb;
	public int speed = 5;
	private int invert = 1;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
	}

	bool GetRay(Vector2 dir)
	{
		bool result = false;

		RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, dir, distance, ~ignoreMask);

		if(hit.collider != null)
		{
			if(CheckObject(hit.collider.gameObject))
			{
				result = true;
				Debug.DrawLine(rayPoint.position, hit.point, Color.green);
				// луч попал в цель
			}
			else
			{
				Debug.DrawLine(rayPoint.position, hit.point, Color.blue);
				// луч попал в любой другой коллайдер
			}
		}
		else
		{
			Debug.DrawRay(rayPoint.position, dir * distance, Color.red);
			// луч никуда не попал
		}
		return result;
	}

	bool CheckObject(GameObject obj)
	{
		if(((1 << obj.layer) & targetMask) != 0)
		{
			return true;
		}

		return false;
	}

	bool Scan() 
	{
		bool hit = false;
		float j = 0;
		for (int i = 0; i < rays; i++)
		{
			var x = Mathf.Sin(j);
			var y = Mathf.Cos(j);

			j += angle * Mathf.Deg2Rad / rays * invert;

			if(x != 0) 
			{
				if(GetRay(rayPoint.TransformDirection(new Vector3(y,-x,0)))) hit = true;
			}

			if(GetRay(rayPoint.TransformDirection(new Vector3(y,x,0)))) hit = true;
		}

		return hit;
	}

	void Update()
	{
		if(Scan())
		{
			Vector3 direction = player.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			direction.Normalize();
			movement = direction;
			transform.rotation = Quaternion.Euler
			(
				transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2
				(
					player.position.y - transform.position.y, player.position.x - transform.position.x
				)
				* Mathf.Rad2Deg
			);

			MoveChar(movement);
		}
		else
		{
			// Поиск цели...
		}
	}

	private void MoveChar(Vector2 direction)
	{
		rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
	}
}
