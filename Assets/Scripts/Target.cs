using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Target : MonoBehaviour
{
	public int points;
    public List<Sprite> People;
    public List<Sprite> BloodSplat;
    public SpriteRenderer DeathRemains;

    private bool _isDead = false;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        int randNum = Random.Range(0, People.Count);
        _spriteRenderer.sprite = People[randNum];
        DeathRemains.enabled = false;
		points = Random.Range(50, 250);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Score();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Score();
	}

	private void Score()
	{
        // TODO: death effects.
        _spriteRenderer.enabled = false;
        DeathRemains.sprite = BloodSplat[Random.Range(0, BloodSplat.Count)];
        DeathRemains.enabled = true;

        if (_isDead)
        {
            return;
        }

        if (LevelManager.instance != null)
		{
			LevelManager.instance.AddScore(points);
		}
	}
}
