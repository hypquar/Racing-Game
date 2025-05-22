using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private Slider _display;

    private float _value;

    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value > _maxValue)
            {
                _value = _maxValue;
            }
            else if (value < _minValue)
            {
                _value = _minValue;
            }
            else
            {
                _value = value;
            }
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        _display.value = _value / (_maxValue - _minValue);
    }
}
