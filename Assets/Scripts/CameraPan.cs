using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    private const int MOUSE_BUTTON = 0;
    private Vector3 _initialClickPosition;

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(MOUSE_BUTTON))
        {
            _initialClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(MOUSE_BUTTON))
        {
            var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            var newPos = _initialClickPosition - difference;
            newPos.x = Camera.main.transform.position.x;
            Camera.main.transform.position = newPos;
        }
    }
}
