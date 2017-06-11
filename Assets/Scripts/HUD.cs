using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
	public Text score;
	public List<Image> whaleIcons;
	public GameObject gameOverPanel;
	public Text gameOverScore;
	public string _nextLevelName;

	private int _lastWhaleNumber;

	private void Awake()
	{
		SetGameOverScreen(false);
	}

	private void Start()
	{
		if (LevelManager.instance != null)
		{
			UpdateWhaleIcon();
		}
	}
	
	private void Update()
	{
		if (LevelManager.instance == null)
		{
			return;
		}
		
		UpdateWhaleIcon();

		if (LevelManager.instance.State == LevelState.GameOver)
		{
			// TODO: show the game over screen.
			SetGameOverScreen(true);
			gameOverScore.text = string.Format("Score: {0:0000000}", LevelManager.instance.Score);
		}

		score.text = string.Format("Score: {0:0000000}", LevelManager.instance.Score);
	}

	private void UpdateWhaleIcon()
	{
		if (LevelManager.instance.whales <= whaleIcons.Count && LevelManager.instance.whales != _lastWhaleNumber)
		{
			for (var i = 0; i < whaleIcons.Count; ++i)
			{
				whaleIcons[i].enabled = i < LevelManager.instance.whales;
			}

			_lastWhaleNumber = LevelManager.instance.whales;
		}
	}

	private void SetGameOverScreen(bool active)
	{
		if (gameOverPanel.activeSelf != active)
		{
			gameOverPanel.SetActive(active);
		}
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(_nextLevelName);
	}

	public void RetryLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
