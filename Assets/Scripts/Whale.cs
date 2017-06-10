using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Whale : MonoBehaviour 
{
	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.gravityScale = 0;
		_rigidbody.drag = 0.15f;
	}

	private void Start()
	{
		Launch(new Vector2(0, 1));
	}

	public void Launch(Vector2 direction)
	{
		_rigidbody.AddForce(direction, ForceMode2D.Impulse);
	}
}
