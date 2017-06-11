using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public static CameraFollow instance;
	public Transform target;
	public Vector3 offset;

	private Transform _transform;

	private void Awake()
	{
		instance = this;
		_transform = GetComponent<Transform>();
	}

	private void OnDestroy()
	{
		instance = null;
	}

	private void Update()
	{
		if (target)
		{
			var pos = target.position;
			if (target.position.y < _transform.position.y + offset.y)
			{
				pos.y = _transform.position.y;
				offset.y = 0;
			}
			_transform.position = pos + offset;
		}
	}

	public void Reset(Vector3 position)
	{
		_transform.position = position + offset;
	}
}
