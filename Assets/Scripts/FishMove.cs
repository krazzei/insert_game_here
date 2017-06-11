using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{

    public List<Sprite> FishSprites;
    public SpriteRenderer SpriteRenderer;
    private Vector3 _direction = Vector3.zero;

    void Awake()
    {
        SpriteRenderer.sprite = FishSprites[Random.Range(0, FishSprites.Count)];
    }

    void Start()
    {
        if(Random.Range(0, 2) > 1)
        {
            //_direction = -1;
        }
    }

    public void SetDirection(Vector3 vector)
    {
        _direction = vector;
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * 5f * Time.deltaTime;
    }
}
