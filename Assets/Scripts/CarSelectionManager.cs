using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CarSelectionManager : MonoBehaviour
{
    public UnityEvent OnBoughtCarInspection;
    public UnityEvent OnNotBoughtCarInspection;

    [SerializeField] private List<CarData> _carDatas;

    [SerializeField] private GameObject _currentCar;
    [SerializeField] private Transform _spawn;

    [SerializeField] private StatDisplay _speedDisplay;
    [SerializeField] private StatDisplay _brakeDisplay;
    [SerializeField] private StatDisplay _nitroDisplay;

    private CarComponent _currentCarComponent;
    private CarData _currentCarData;
    private int _currentCarIndex = 0;

    public int CurrentCarIndex
    {
        get
        {
            return _currentCarIndex;
        }
        private set
        {
            _currentCarIndex = value;
            SwitchCar(_carDatas[_currentCarIndex].PrefabPath);
        }
    }

    public CarData CurrentCarData
    {
        get
        {
            return _currentCarData;
        }
        set
        {
            if (_currentCarComponent.CarData.IsBought)
            {
                OnBoughtCarInspection.Invoke();
            }
            else
            {
                OnNotBoughtCarInspection.Invoke();
            }
            _currentCarData = value;  
        }
    }

    private void Start()
    {
        SwitchCar(_carDatas[CurrentCarIndex].PrefabPath);
    }

    public void ChangeSelectedCar(int increment)
    {
        CurrentCarIndex = (CurrentCarIndex + increment + _carDatas.Count) % _carDatas.Count;
    }
    public void SwitchCar(string prefabPath)
    {
        if (_currentCar != null)
        {
            Destroy(_currentCar);
        }

        GameObject newCar = Resources.Load<GameObject>(prefabPath).gameObject;
        _currentCar = Instantiate(newCar, _spawn.position, Quaternion.identity, _spawn);

        _currentCar.TryGetComponent<CarComponent>(out _currentCarComponent);
        CurrentCarData = _currentCarComponent.CarData;

        _speedDisplay.Value = CurrentCarData.Speed;
        _brakeDisplay.Value = CurrentCarData.Braking;
        _nitroDisplay.Value = CurrentCarData.Nitro;
    }
    public void ChangeSmokeColorHex(string colorHex)
    {
        _currentCarComponent.SmokeColor = colorHex;
    }
    public void ChangeRimsColorHex(string colorHex)
    {
        _currentCarComponent.RimsColor = colorHex;
    }
}
