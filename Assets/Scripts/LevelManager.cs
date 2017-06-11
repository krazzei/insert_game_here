using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	// How many whales you have for this level
	public int whales;
	// The player to spawn
	public GameObject playerObj;
	public Transform playerSpawn;
	public GameObject whaleObj;
	public Transform whaleSpawn;
    public Whale WhaleInstance;

	// Can be null
	public static LevelManager instance;
	
	private int _score;
	public int Score { get { return _score; } } 

	private LevelState _state;
	public LevelState State { get { return _state; } }

	private void Awake()
	{
		instance = this;
		GameObject.Instantiate(playerObj, playerSpawn.position, playerSpawn.rotation);
		WhaleInstance = GameObject.Instantiate(whaleObj, whaleSpawn.position, whaleSpawn.rotation).GetComponent<Whale>();
		_state = LevelState.Whaling;
	}

	private void Start()
	{
		CameraFollow.instance.Reset();
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
        whales -= 1;

		if (whales == 0)
		{
			_state = LevelState.GameOver;
			return;
		}

		WhaleInstance = GameObject.Instantiate(whaleObj, whaleSpawn.position, whaleSpawn.rotation).GetComponent<Whale>();
		CameraFollow.instance.Reset();
	}
}
