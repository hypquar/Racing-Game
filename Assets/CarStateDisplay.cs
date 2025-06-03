using TMPro;
using UnityEngine;

public class CarStateDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedDisplay;
    [SerializeField] private TextMeshProUGUI _gearDisplay;
    [SerializeField] private RectTransform _rpmIndicator;
    [SerializeField] private Engine _engine;
    [SerializeField] private Transmission _transmission;
    [SerializeField] private Rigidbody _playerRb;

    [SerializeField] private float _indicatorMinAngle;
    [SerializeField] private float _indicatorMaxAngle;

    private string _speedText;
    private string _gearText;
    private float _rpmAngleValue;

    public float Speed
    {
        set
        {
            _speedText = $"{(int)(value * 3.6f)}";
        }
    }

    public int Gear
    {
        set
        {
            if (value == 0)
            {
                _gearText = "R";
            }
            else if (value == 1)
            {
                _gearText = "N";
            }
            else
            {
                _gearText = $"{value - 1}";
            }
        }
    }

    public float Rpm
    {
        set
        {
            _rpmAngleValue = (value / (_engine.MaxRpm - _engine.MinRpm)) * (_indicatorMaxAngle - _indicatorMinAngle);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageDisplay();
    }

    void ManageDisplay()
    {
        Speed = _playerRb.linearVelocity.magnitude;
        _speedDisplay.text = _speedText;
        Gear = _transmission.CurrentGear;
        _gearDisplay.text = _gearText;
        Rpm = _engine.Rpm;
        _rpmIndicator.transform.rotation = Quaternion.Euler(0, 0, _rpmAngleValue);
    }
}
