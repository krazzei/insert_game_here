using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Mine : MonoBehaviour
{
	public int power;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		var whale = collider.GetComponent<Whale>();
		var body = whale.GetComponent<Rigidbody2D>(); 
		whale.Launch(body.velocity * power);

		Destroy(gameObject);
	}
}
