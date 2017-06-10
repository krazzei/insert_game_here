using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPowerState : CharacterState
{
    private float _powerMeterFillAmount = 0f;
    private float _powerMeterFillRate = 0.5f;
    private bool _meterFilling = true;

    public override void EnterState(Poseidon character)
    {
        
    }

    public override void ExitState(Poseidon character)
    {
        
    }

    public override void Update(Poseidon character)
    {
        if(_powerMeterFillAmount >= 1f)
        {
            _meterFilling = false;
        }
        else if(_powerMeterFillAmount <= 0f)
        {
            _meterFilling = true;
        }

        _powerMeterFillAmount += _powerMeterFillAmount * Time.deltaTime;
        character.SetPower(_powerMeterFillAmount);
    }
}
