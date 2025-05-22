using CarGame;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxisInfo> _axisInfos;
    [SerializeField] private float _maxTorque;
    [SerializeField] private float _maxSteeringAngle;
    [SerializeField] private float _maxBrakesTorque;
    [SerializeField] private float _steeringSensitivity;

    [SerializeField] private Engine _engine;
    [SerializeField] private Transmission _transmission;

    private Car _inputActions;
    private float _wheelRpm;

    public float Speed
    {
        get
        {
            return _engine.EnginePower;
        }
        set
        {
            _engine.EnginePower = value;
        }
    }

    public float GasInput
    {
        get 
        {
            return _inputActions.CarControls.Gas.ReadValue<float>();
        }
    }

    private void Awake()
    {
        _inputActions = new Car();
        _transmission.AxisInfos = _axisInfos;
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
        float steering = _maxSteeringAngle * _inputActions.CarControls.Steer.ReadValue<Vector2>().x;
        float torque = _engine.Torque;
        float brakesTorque = _maxBrakesTorque * _inputActions.CarControls.Brakes.ReadValue<float>();

        foreach (AxisInfo axisInfo in _axisInfos)
        {

            if (axisInfo.IsMotor)
            {
                axisInfo.RightWheel.motorTorque = torque * (int)GasInput;
                axisInfo.LeftWheel.motorTorque = torque * (int)GasInput;
            }
            
            if (axisInfo.IsSteering)
            {
                axisInfo.RightWheel.steerAngle = steering;
                axisInfo.LeftWheel.steerAngle= steering;
            }

            axisInfo.RightWheel.brakeTorque = brakesTorque;
            axisInfo.LeftWheel.brakeTorque= brakesTorque;

            AllignVisualWheel(axisInfo.LeftWheel);
            AllignVisualWheel(axisInfo.RightWheel);
        }
    }

    private void AllignVisualWheel(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) return;

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        visualWheel.position = position;
        visualWheel.rotation = rotation;
    }
}
