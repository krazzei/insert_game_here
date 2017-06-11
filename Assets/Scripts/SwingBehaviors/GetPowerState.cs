using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPowerState : CharacterState
{
    private float _powerMeterFillAmount = 0f;
    private float _powerMeterFillRate = 1f;
    private bool _meterFilling = true;

    public override void EnterState(Poseidon character)
    {
        
    }

    public override void ExitState(Poseidon character)
    {
        
    }

    public override void Update(Poseidon character)
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            character.SetState(new SwingClubState());
        }

        if(_powerMeterFillAmount >= 1f)
        {
            _meterFilling = false;
        }
        else if(_powerMeterFillAmount <= 0f)
        {
            _meterFilling = true;
        }

        if(_meterFilling)
        {
            _powerMeterFillAmount += _powerMeterFillRate * Time.deltaTime;
        }
        else
        {
            _powerMeterFillAmount -= _powerMeterFillRate * Time.deltaTime;
        }

        character.SetPower(_powerMeterFillAmount);
    }
}
