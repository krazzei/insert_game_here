using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Beach : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		var body = other.GetComponent<Rigidbody2D>();
		if (body)
		{
			var distance = body.velocity.magnitude / 2;
			Debug.Log("Distance " + distance);
			var dir = body.velocity.normalized;
			var dir3 = new Vector3(dir.x, dir.y, 0);

			body.velocity = Vector2.zero;

			iTween.MoveAdd(other.gameObject, (dir3 * distance), 2);
			var hash = new Hashtable();
			hash.Add("scale", Vector3.one * 3);
			hash.Add("time", 0.25f);
			hash.Add("oncomplete", "ScaleDown");
			hash.Add("oncompletetarget", gameObject);
			hash.Add("oncompleteparams", other.gameObject);
			iTween.ScaleTo(other.gameObject, hash);
		}
	}

	private void ScaleDown(GameObject other)
	{
		iTween.ScaleTo(other, Vector3.one, 2);
	}
}
