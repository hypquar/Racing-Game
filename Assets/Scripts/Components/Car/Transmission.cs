using CarGame;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Transmission : MonoBehaviour
{
    [SerializeField] private float[] _gearRatios;
    [SerializeField] private float _differentialRatio = 0.5f;
    [SerializeField] private float ratio;

    private float _wheelRpm;
    private int _currentGear = 2;
    private List<AxisInfo> _axisInfos;
    private Car _inputActions;

    public float WheelRpm
    {
        get
        {
            return _wheelRpm;
        }
        private set
        {
            _wheelRpm = value;
        }
    }

    public int CurrentGear
    {
        get
        { 
            return _currentGear; 
        }
    }

    public float CurrentGearRatio
    {
        get
        {
            return _gearRatios[_currentGear];
        }
    }

    public float DifferentialRatio
    {
        get
        {
            return _differentialRatio;
        }
        set
        {
            _differentialRatio = value;
        }
    }

    public List<AxisInfo> AxisInfos
    {
        get
        {
            return _axisInfos;
        }
        set
        {
            _axisInfos = value;
        }
    }

    private void Awake()
    {
        _inputActions = new Car();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void FixedUpdate()
    {
        CalculateWheelRpm();
    }

    public void CalculateWheelRpm()
    {
        float sum = 0;
        float wheels = 0;
        foreach (var axis in _axisInfos)
        {
            if (axis.IsMotor)
            {
                sum += axis.LeftWheel.rpm + axis.RightWheel.rpm;
                wheels += 2f;
            }
        }
        _wheelRpm = Mathf.Abs((sum / wheels) * CurrentGearRatio * DifferentialRatio);
    }

    public void ShiftUp(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (_currentGear < _gearRatios.Length - 1)
            {
                _currentGear++;
            }

            Debug.Log(_currentGear);
        }
    }

    public void ShiftDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (_currentGear > 0)
            {
                _currentGear--;
            }

            Debug.Log(_currentGear);
        }
    }
}
