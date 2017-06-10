using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindComponent : MonoBehaviour {

    [SerializeField]
    private Vector2 _windValue = new Vector2(0.1f, 0.05f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Whale>().Launch(_windValue);
    }
}
