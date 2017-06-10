using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Target : MonoBehaviour
{
	public int points;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Score();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Score();
	}

	private void Score()
	{
		// TODO: death effects.
		LevelManager.instance.AddScore(points);
		Destroy(gameObject);
	}
}
