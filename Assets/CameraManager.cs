using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private List<Camera> _switchableCameras;
    [SerializeField] private Camera _finishCamera;

    private int _currentCameraIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera[] objects = Resources.FindObjectsOfTypeAll<Camera>();

        foreach(var cam in objects)
        {
            if (cam.gameObject.scene.isLoaded)
            {
                if (cam.gameObject.CompareTag("SwitchableCamera"))
                {
                    _switchableCameras.Add(cam);
                }
                if (cam.gameObject.CompareTag("FinishCamera"))
                {
                    _finishCamera = cam;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        _currentCameraIndex = (_currentCameraIndex + 1) % _switchableCameras.Count;
        foreach (var cam in _switchableCameras)
        {
            if (_switchableCameras.IndexOf(cam) == _currentCameraIndex)
            {
                cam.gameObject.SetActive(true);
                if (cam.TryGetComponent<AudioListener>(out AudioListener listener))
                {
                    listener.enabled = true;
                }
            }
            else
            {
                if (cam.TryGetComponent<AudioListener>(out AudioListener listener))
                {
                    listener.enabled = false;
                }
                cam.gameObject.SetActive(false);
            }
        }
    }
}
