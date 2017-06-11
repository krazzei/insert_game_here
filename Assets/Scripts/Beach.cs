using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Beach : MonoBehaviour
{
	private Vector3 _orgScale, _finalScale;
    private Rigidbody2D _body;
    private Collider2D _bodyCollider;
    private Vector2 _initialVelocity;
    private Vector3 _landPos;
    private Vector3 _hitPos;
    private bool _isRolling = false;
    private bool _isOn = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (_body)
		{
			return;
		}

        _body = other.GetComponent<Rigidbody2D>();
		if (_body)
		{
            _isOn = true;
            _bodyCollider = _body.GetComponent<Collider2D>();
            _bodyCollider.enabled = false;
            var distance = _body.velocity.magnitude;
			var dir = _body.velocity.normalized;
			var dir3 = new Vector3(dir.x, dir.y, 0);
            _initialVelocity = _body.velocity;
            //_body.velocity = Vector2.zero;
            _hitPos = other.transform.position;
            _landPos = _hitPos + new Vector3(_body.velocity.x, _body.velocity.y, other.gameObject.transform.position.z);
            Debug.DrawLine(other.transform.position, _landPos, Color.blue, 1000f);
            _orgScale = other.transform.localScale;
            _finalScale = _orgScale * 3;
            //iTween.MoveAdd(other.gameObject, (dir3 * distance), 4);
            var hash = new Hashtable();
			hash.Add("scale", _finalScale);
			hash.Add("time", 0.3f);
			iTween.ScaleTo(other.gameObject, hash);
		}
	}

    private void LateUpdate()
    {
        if(_body == null || !_isOn)
        {
            return;
        }
        
        if(!_isRolling)
        {
            
            var distancePercentage = Vector3.Distance(_landPos, _body.transform.position) / Vector3.Distance(_landPos, _hitPos);
            var diffScale = _finalScale - _orgScale;
            var currentScale = diffScale * distancePercentage + _orgScale;
            _body.transform.localScale = currentScale;
            if(Vector3.Distance(_body.transform.position, _landPos) < 10f)
            {
				var whale = _body.GetComponent<Whale>();
				whale.Dead();
                _isRolling = true;
                iTween.ScaleTo(_body.gameObject, _orgScale, 0.2f);
            }
        }
        else
        {
            _bodyCollider.enabled = true;
            var subVel = -_body.velocity * 2f * Time.deltaTime; //new Vector2(100,100) * Time.deltaTime;
            _body.velocity = _body.velocity + subVel;
            if(Mathf.Approximately(_body.velocity.sqrMagnitude, 0))
            {
                _isOn = false;
				Destroy(_body.gameObject);
                StartCoroutine(WaitForDeath());
				_body = null;
            }
        }
        //_body.gameObject.transform.localScale = _orgScale + _body.velocity.magnitude / _initialVelocity.magnitude * ((_orgScale * 3) - _orgScale);
    }

	private IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(0.5f);

		if (LevelManager.instance != null)
		{
            _isOn = false;
            LevelManager.instance.RemoveWhale();
            _isRolling = false;
            _body = null;
		}
	}
}
