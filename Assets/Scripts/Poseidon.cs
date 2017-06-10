using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poseidon : MonoBehaviour
{
    public GameObject GolfAngleArm;
    public GameObject GolfArrow;
    public Image PowerMeter;
    private bool _isSwinging = false;
    private CharacterState _state;
    private Vector2 _direction;
    private float _power;
    private IList<SwingData> _swings = new List<SwingData>();

    private void Start ()
    {
        GolfAngleArm.SetActive(false);
        SetState(new GetDirectionState());
    }
    
    public void SetState(CharacterState newState)
    {
        if(_state != null)
        {
            _state.ExitState(this);
        }
        _state = newState;

        if(_state != null)
        {
            _state.EnterState(this);
        }
    }

    public void StartSwinging()
    {
        _isSwinging = true;
    }

    public void SetArrowDirection(Quaternion direction)
    {
        _direction = direction.eulerAngles;
        GolfAngleArm.transform.rotation = direction;
    }

    public void SetPower(float power)
    {
        _power = power;
    }

    public void ShowArrow(bool showArrow)
    {
        GolfAngleArm.SetActive(showArrow);
    }

    public void Update ()
    {
        _state.Update(this);
    }
}
