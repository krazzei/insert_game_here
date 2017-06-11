using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Beach : MonoBehaviour
{
	private Vector3 _orgScale;
    private Rigidbody2D _body;
    private Vector2 _initialVelocity;

	private void OnTriggerEnter2D(Collider2D other)
	{
        _body = other.GetComponent<Rigidbody2D>();
		if (_body)
		{
			var distance = _body.velocity.magnitude;
			var dir = _body.velocity.normalized;
			var dir3 = new Vector3(dir.x, dir.y, 0);
            _initialVelocity = _body.velocity;
            //_body.velocity = Vector2.zero;

            _orgScale = other.transform.localScale;

			//iTween.MoveAdd(other.gameObject, (dir3 * distance), 4);
			var hash = new Hashtable();
			hash.Add("scale", _orgScale * 3);
			hash.Add("time", 1f);
			//hash.Add("oncomplete", "ScaleDown");
			hash.Add("oncompletetarget", gameObject);
			hash.Add("oncompleteparams", other.gameObject);
			iTween.ScaleTo(other.gameObject, hash);
		}
	}

    private void Update()
    {
        if(_body == null)
        {
            var subVel = new Vector2(10, 10) * Time.deltaTime;
            _body.velocity -= Vector2.Max(_body.velocity - subVel, Vector3.zero);
            _body.gameObject.transform.localScale = _body.velocity.magnitude / _initialVelocity.magnitude * ((_orgScale * 3) - _orgScale);
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
