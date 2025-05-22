using UnityEngine;

public class CarComponent : MonoBehaviour
{
    [SerializeField] private CarData _carData;

    [SerializeField] private float _speed;
    [SerializeField] private float _braking;
    [SerializeField] private float _nitro;
    [SerializeField] private float _price;
    [SerializeField] private string _smokeColorHex;
    [SerializeField] private string _rimsColorHex;
    [SerializeField] private string _prefabPath;

    [SerializeField] private Material _smokeMaterial;
    [SerializeField] private Material _rimsMaterial;
    [SerializeField] private CarController _controller;

    public CarData CarData
    {
        get
        {
            return _carData;
        }
    }
    
    public string SmokeColor
    {
        get
        {
            return _smokeColorHex;
        }
        set
        {
            _smokeColorHex = value;
            if (ColorUtility.TryParseHtmlString(_smokeColorHex, out Color color))
            {
                _smokeMaterial.color = color;
            }
            SaveCustomization();
        }
    }

    public string RimsColor
    {
        get
        {
            return _rimsColorHex;
        }
        set
        {
            _rimsColorHex = value;
            if (ColorUtility.TryParseHtmlString(_rimsColorHex, out Color color))
            {
                _rimsMaterial.color = color;
            }
            SaveCustomization();
        }
    }

    private void Start()
    {
        _speed = _carData.Speed;
        _braking = _carData.Braking;
        _nitro = _carData.Nitro;
        _price = _carData.Price;
        _smokeColorHex = _carData.SmokeColor;
        _rimsColorHex = _carData.RimsColor;
        _prefabPath = _carData.PrefabPath;

        _controller.Speed = _speed;
    }

    public void SaveCustomization()
    {
        _carData.SmokeColor = SmokeColor;
        _carData.RimsColor = RimsColor;
    }
}
