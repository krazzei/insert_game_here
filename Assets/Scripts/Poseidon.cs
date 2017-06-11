using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poseidon : MonoBehaviour
{
    public float MinPower;
    public float MaxPower;
    public GameObject GolfAngleArm;
    public GameObject GolfArrow;
    public Image PowerMeter;
    private float _maxMinPowerDifference;
    private bool _isSwinging = false;
    private CharacterState _state;
    private Vector2 _direction;
    private float _power;
    private IList<SwingData> _swings = new List<SwingData>();

    private void Start ()
    {
        _maxMinPowerDifference = MaxPower - MinPower;
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

    public void SetPower(float powerMeterPercentage)
    {
        _power = _maxMinPowerDifference * powerMeterPercentage;
        PowerMeter.fillAmount = powerMeterPercentage;
    }

    public void SwingClub()
    {
        var swingData = new SwingData() { Direction = _direction, Power = _power };
        _swings.Add(swingData);
        LevelManager.instance.WhaleInstance.Launch(_direction * _power);
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
