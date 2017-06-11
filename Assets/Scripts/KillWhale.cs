using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KillWhale : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Whale>() != null)
		{
			Destroy(other.gameObject);
			LevelManager.instance.RemoveWhale();
		}
	}
}
