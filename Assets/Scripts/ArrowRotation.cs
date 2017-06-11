using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowRotation : MonoBehaviour
{

    public GameObject RotationArm;
    public GameObject ObjectToScale;

    public System.Action<Vector3> OnDirectionPicked = delegate { };

    private bool _isOn = false;
    private float _angle = 0;
    private float _angleChangeRatePerSecond = 45f;
    //private Vector3 _arrowScale = Vector3.one;
    private Vector3 _arrowScaleChangeRate = new Vector3(0.4f, 0.4f, 0.4f);
    private float _minScale = 1f;
    private float _maxScale = 1.3f;
    private Vector3 _originalArrowScale = Vector3.one;
    private bool _arrowGrowing = true;
    private Quaternion _currentRotation;

    public void Begin()
    {
        _isOn = true;
        ObjectToScale.SetActive(true);
        _originalArrowScale = ObjectToScale.transform.localScale;
    }

    public void End()
    {
        _isOn = false;
        ObjectToScale.transform.localScale = _originalArrowScale;
        enabled = false;
    }

    public void Hide()
    {
        ObjectToScale.SetActive(false);
    }

    private void Awake()
    {
        ObjectToScale.SetActive(false);
    }

    private Vector3 CalculateArrowScale(GameObject objectToScale)
    {
        var retVal = objectToScale.transform.localScale;

        if (retVal.x >= _maxScale)
        {
            _arrowGrowing = false;
        }
        else if (retVal.x <= _minScale)
        {
            _arrowGrowing = true;
        }

        if (_arrowGrowing)
        {
            retVal += _arrowScaleChangeRate * 1.5f * Time.deltaTime;
        }
        else
        {
            retVal -= _arrowScaleChangeRate * Time.deltaTime;
        }

        return retVal;
    }

    private void Update()
    {
        if(!_isOn)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            var direction = _currentRotation * Vector3.up;
            OnDirectionPicked(direction);
            End();
            return;
        }

        var updatedArrowScale = CalculateArrowScale(ObjectToScale);
        iTween.ScaleUpdate(ObjectToScale, updatedArrowScale, 0.1f);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _angle += Time.deltaTime * _angleChangeRatePerSecond;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _angle -= Time.deltaTime * _angleChangeRatePerSecond;
        }
        _currentRotation = Quaternion.Euler(new Vector3(0, 0, _angle));
        RotationArm.transform.rotation = _currentRotation;
    }
}
