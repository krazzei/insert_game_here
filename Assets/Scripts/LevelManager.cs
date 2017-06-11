using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	// How many whales you have for this level
	public int whales;
	public GameObject whaleObj;
	public Transform whaleSpawn;
    public Whale WhaleInstance;
	public Sprite posidonSwing;
	public Sprite posidonTee;
	public SpriteRenderer posidonRenderer;

	// Can be null
	public static LevelManager instance;
	
	private int _score;
	public int Score { get { return _score; } } 

	private LevelState _state;
	public LevelState State { get { return _state; } }

	private void Awake()
	{
		instance = this;
		WhaleInstance = GameObject.Instantiate(whaleObj, whaleSpawn.position, whaleSpawn.rotation).GetComponent<Whale>();
		_state = LevelState.Whaling;
	}

	private void Start()
	{
		CameraFollow.instance.Reset(whaleSpawn.position);
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
		CameraFollow.instance.Reset(whaleSpawn.position);
		posidonRenderer.sprite = posidonTee;
	}

	public void SwingPosidon()
	{
		posidonRenderer.sprite = posidonSwing;
	}
}
