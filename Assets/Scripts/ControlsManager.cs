using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsManager : MonoBehaviour
{
    private ControlModes _currentMode;
    [SerializeField] private PlayerInput _input;
    public void Change(bool value)
    {
        if(value)
        {
            _currentMode = ControlModes.Keyboard;
            Apply();
        }
        else
        {
            _currentMode = ControlModes.Mouse;
            Apply();
        }
    }

    private void Apply()
    {
        if (_currentMode == ControlModes.Keyboard)
        {
            _input.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current, Mouse.current);
        }
        if (_currentMode == ControlModes.Mouse)
        {
            _input.SwitchCurrentControlScheme("Mouse", Keyboard.current, Mouse.current);
        }

        Debug.Log("Current Control Scheme: " + _input.currentControlScheme);
    }
}

public enum ControlModes
{
    Keyboard,
    Mouse,
}
