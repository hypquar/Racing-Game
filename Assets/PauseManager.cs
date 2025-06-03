using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private KeyCode _pauseKey;
    [SerializeField] private RectTransform _pauseMenu;

    private bool _isToggled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isToggled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        Time.timeScale = _isToggled ? 1f : 0;
        _pauseMenu.gameObject.SetActive(!_isToggled);

        _isToggled = !_isToggled;
    }
}
