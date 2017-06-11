using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Beach : MonoBehaviour
{
	private Vector3 _orgScale;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var body = other.GetComponent<Rigidbody2D>();
		if (body)
		{
			var distance = body.velocity.magnitude / 2;
			var dir = body.velocity.normalized;
			var dir3 = new Vector3(dir.x, dir.y, 0);

			body.velocity = Vector2.zero;

			_orgScale = other.transform.localScale;

			iTween.MoveAdd(other.gameObject, (dir3 * distance), 2);
			var hash = new Hashtable();
			hash.Add("scale", _orgScale * 3);
			hash.Add("time", 0.25f);
			hash.Add("oncomplete", "ScaleDown");
			hash.Add("oncompletetarget", gameObject);
			hash.Add("oncompleteparams", other.gameObject);
			iTween.ScaleTo(other.gameObject, hash);
		}
	}

	private void ScaleDown(GameObject other)
	{
		iTween.ScaleTo(other, _orgScale, 2);

		// todo explode
		Destroy(other, 3);

		StartCoroutine(WaitForDeath());
	}

	private IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(3.0f);

		if (LevelManager.instance != null)
		{
			LevelManager.instance.RemoveWhale();
		}
	}
}
