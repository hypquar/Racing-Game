using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Engine : MonoBehaviour
{
    public const float ToHorsePowerConversionRatio = 5252f;

    public UnityEvent OnLowRpm;
    public UnityEvent OnMidRpm;
    public UnityEvent OnHighRpm;

    [SerializeField] private Transmission _transmission;
    [SerializeField] private CarController _controller;

    [SerializeField] private AnimationCurve _horsePowerToRpmCurve;

    [SerializeField] private float _enginePower;
    [SerializeField] private float _maxRpm;
    [SerializeField] private float _idleRpm;

    [SerializeField] private float _rpm;
    [SerializeField] private float _torque;

    public float Rpm
    {
        get
        {
            return _rpm;
        }
        set
        {
            if (value > _maxRpm)
            {
                _rpm = _maxRpm;
            }
            else if (value < _idleRpm)
            {
                _rpm = _idleRpm;
            }
            else
            {
                _rpm = value;
            }
        }
    }

    public float Torque
    {
        get
        {
             _torque = (_horsePowerToRpmCurve.Evaluate(_rpm / _maxRpm) * _enginePower / _rpm) * _transmission.CurrentGearRatio * _transmission.DifferentialRatio * ToHorsePowerConversionRatio;
             return _torque;
        }
    }

    public float EnginePower
    {
        get
        {
            return _enginePower;
        }
        set
        {
            _enginePower = value;
        }
    }

    public float MinRpm
    {
        get
        {
            return _idleRpm;
        }
    }

    public float MaxRpm
    {
        get
        {
            return _maxRpm;
        }
    }

    private void FixedUpdate()
    {
        CalculateRpm();

        if (_rpm <= _idleRpm * 1.1f)
        {
            OnLowRpm.Invoke();
        }
        if (_rpm > _idleRpm * 1.1f && _rpm < _maxRpm * 0.7f)
        {
            OnMidRpm.Invoke();
        }
        if (Rpm > _maxRpm * 0.7f)
        {
            OnHighRpm.Invoke();
        }
    }

    private void CalculateRpm()
    {
        if (_transmission.CurrentGear == 1)
        {
            Rpm = Mathf.Lerp(_rpm, Mathf.Max(_idleRpm, _maxRpm * _controller.GasInput), Time.deltaTime);
        }
        else
        {
            Rpm = Mathf.Lerp(_rpm, Mathf.Max(_idleRpm, _transmission.WheelRpm), Time.deltaTime); 
        }
    }
}
