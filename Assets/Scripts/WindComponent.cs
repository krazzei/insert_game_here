using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindComponent : MonoBehaviour
{
	[SerializeField]
	private Vector2 windValue = new Vector2(0.1f, 0.05f);

	private void OnTriggerStay2D(Collider2D other)
	{
		other.GetComponent<Whale>().Push(windValue);
	}
}
