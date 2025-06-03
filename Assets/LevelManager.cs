using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelSetting _lvlSetting;
    [SerializeField] private float _time;
    [SerializeField] private float _penaltyTime;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CarData _playerCarData;

    private GameObject _carObject;
    private float _oneStarScore;
    private float _twoStarsScore;
    private float _threeStarsScore;
    private float _scoreDelay;

    public GameObject Car
    {
        get
        {
            return _carObject;
        }
        private set
        {
            _carObject = value;
        }
    }

    public float ScoreDelay
    {
        get
        {
            return _scoreDelay;
        }
        private set
        {
            _scoreDelay = value;
        }
    }

    private void Start()
    {
        //SpawnCar();
    }

    void SpawnCar()
    {
        GameObject prefab = Resources.Load<GameObject>(_playerCarData.PrefabPath);
        Car = Instantiate(prefab, _spawnPoint.position, Quaternion.identity);
    }

    void LoadLevelSettings()
    {
        _oneStarScore = _lvlSetting.OneStarPoints;
        _twoStarsScore = _lvlSetting.TwoStarsPoints;
        _threeStarsScore = _lvlSetting.ThreeStarsPoints;
        ScoreDelay = _lvlSetting.ScoreDelay;
    }
}