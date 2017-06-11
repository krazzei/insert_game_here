using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOverTime : MonoBehaviour
{
    public float SpawnRate = 2000;
    public Vector3 FishDirection = Vector3.left;
    public GameObject FishPrefab;
    private float _lastSpawnTime;

    // Use this for initialization
    void Start()
    {
        _lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(_lastSpawnTime + SpawnRate < Time.time)
        {
            _lastSpawnTime = Time.time;
            var fm = Instantiate(FishPrefab, transform.position, transform.rotation).GetComponent<FishMove>();
            fm.SetDirection(FishDirection);
        }
    }
}
