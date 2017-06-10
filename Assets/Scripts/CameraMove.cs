using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]
    private float cameraSpeed = 5;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.position = new Vector2(transform.position.x, this.transform.position.y + cameraSpeed);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.position = new Vector2(transform.position.x, this.transform.position.y - cameraSpeed);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector2(transform.position.x - cameraSpeed, this.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.position = new Vector2(transform.position.x + cameraSpeed, this.transform.position.y);
        }
    }
}
