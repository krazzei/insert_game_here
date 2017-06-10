using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDirectionState : CharacterState
{
    private Vector2 _prevMousePosition, _currentMousePosition;
    private float _angle = 0;
    private float _angleChangeRatePerSecond = 45f;
    private Vector3 _arrowScale = Vector3.one;
    private Vector3 _arrowScaleChangeRate = new Vector3(0.4f, 0.4f, 0.4f);
    private float _minScale = 1f;
    private float _maxScale = 1.3f;
    private Vector3 _originalArrowScale = Vector3.one;
    private bool _arrowGrowing = true;

    public override void EnterState(Poseidon character)
    {
        character.ShowArrow(true);
    }

    public override void ExitState(Poseidon character)
    {
        character.GolfAngleArm.transform.localScale = _originalArrowScale;
    }

    private Vector3 CalculateArrowScale(GameObject arrowObject)
    {
        var retVal = arrowObject.transform.localScale;

        if(retVal.x >= _maxScale)
        {
            _arrowGrowing = false;
        }
        else if(retVal.x <= _minScale)
        {
            _arrowGrowing = true;
        }

        if(_arrowGrowing)
        {
            retVal += _arrowScaleChangeRate * 1.5f * Time.deltaTime;
        }
        else
        {
            retVal -= _arrowScaleChangeRate * Time.deltaTime;
        }

        return retVal;
    }

    public override void Update(Poseidon character)
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            character.SetState(new GetPowerState());
            return;
        }

        var updatedArrowScale = CalculateArrowScale(character.GolfArrow);
        iTween.ScaleUpdate(character.GolfArrow, updatedArrowScale, 0.1f);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _angle += Time.deltaTime * _angleChangeRatePerSecond;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _angle -= Time.deltaTime * _angleChangeRatePerSecond;
        }
        var rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
        character.SetArrowDirection(rotation);
    }
}
