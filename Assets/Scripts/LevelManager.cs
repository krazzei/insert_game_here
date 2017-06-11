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
    public Poseidon PlayerInstance;

	// Can be null
	public static LevelManager instance;
	
	private int _score;
	public int Score { get { return _score; } } 

	private void Awake()
	{
		instance = this;
		PlayerInstance = GameObject.Instantiate(playerObj, playerSpawn.position, playerSpawn.rotation).GetComponent<Poseidon>();
		WhaleInstance = GameObject.Instantiate(whaleObj, whaleSpawn.position, whaleSpawn.rotation).GetComponent<Whale>();
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
			Debug.Log("Game Over!");
		}
	}
}
