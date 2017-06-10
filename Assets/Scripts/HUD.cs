using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	public Text score;
	public List<Image> whaleIcons;

	private void Start()
	{
		if (LevelManager.instance != null && LevelManager.instance.whales <= whaleIcons.Count)
		{
			for (var i = 0; i < whaleIcons.Count; ++i)
			{
				whaleIcons[i].enabled = i < LevelManager.instance.whales;
			}
		}
		else
		{
			Debug.LogError("You done goofed");
		}
	}
	
	private void Update()
	{
		if (LevelManager.instance == null)
		{
			return;
		}
		
		score.text = string.Format("Score: {0:0000000}", LevelManager.instance.Score);
	}
}
