using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	// How many whales you have for this level
	public int _whales;
	// The player to spawn
	public GameObject _playerObj;
	public Transform _playerSpawn;
	public GameObject _whaleObj;
	public Transform _whaleSpawn;

	// Can be null
	public static LevelManager instance;
	
	private int _score;

	private void Awake()
	{
		instance = this;

		GameObject.Instantiate(_playerObj, _playerSpawn.position, _playerSpawn.rotation);
		GameObject.Instantiate(_whaleObj, _whaleSpawn.position, _whaleSpawn.rotation);
	}

	private void OnDestroy()
	{
		instance = null;
	}

	public void AddScore(int score)
	{
		_score += score;
	}

	public void RemoveWhale()
	{
		_whales -= 1;
		if (_whales == 0)
		{
			Debug.Log("Game Over!");
		}
	}
}
