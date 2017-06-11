using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeter : MonoBehaviour
{

    public Image Meter;
    public System.Action<float> OnPowerPicked = delegate { };

    private float _powerMeterFillAmount = 0f;
    private float _powerMeterFillRate = 1f;
    private bool _isOn = false;
    private bool _meterFilling = true;

    private void Awake()
    {
        Meter.fillAmount = 0;
        enabled = false;
        _isOn = false;
    }

    private void Start()
    {
        
    }

    public void Begin()
    {
        enabled = true;
        _isOn = true;
    }

    public void End()
    {
        _isOn = false;
        enabled = false;
    }

    public void Hide()
    {
        Meter.enabled = false;
    }

    private void Update()
    {
        if (!_isOn)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnPowerPicked(_powerMeterFillAmount);
            End();
            return;
        }

        if (_powerMeterFillAmount >= 1f)
        {
            _meterFilling = false;
        }
        else if (_powerMeterFillAmount <= 0f)
        {
            _meterFilling = true;
        }

        if (_meterFilling)
        {
            _powerMeterFillAmount += _powerMeterFillRate * Time.deltaTime;
        }
        else
        {
            _powerMeterFillAmount -= _powerMeterFillRate * Time.deltaTime;
        }

        Meter.fillAmount = _powerMeterFillAmount;
    }
}
