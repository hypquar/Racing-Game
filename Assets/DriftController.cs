using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DriftController : MonoBehaviour
{
    public UnityEvent OnDriftStart;
    public UnityEvent OnScoringStart;
    public UnityEvent OnDriftEnd;
    public UnityEvent OnScoringEnd;

    [SerializeField] private bool _isDrifting;
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private float _timeToStartCountingScore;
    [SerializeField] private float _driftStartAngle;
    [SerializeField] private float _minimalSpeed;
    [SerializeField] private float _scoringDelay;

    private Rigidbody _rb;
    private float _speed;
    private float _angle;
    private bool _isScoring;

    public float Speed
    {
        get
        {
            return _speed;
        }
        private set
        {
            _speed = value;
        }
    }

    public float Angle
    {
        get
        {
            return _angle;
        }
        set
        {
            if (value < 120)
            {
                _angle = value;
            }
            else
            {
                _angle = 0;
            }
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ManageDrift();
    }

    void ManageDrift()
    {
        Speed = _rb.linearVelocity.magnitude;
        Angle = Vector3.Angle(_rb.transform.forward, (_rb.linearVelocity + _rb.transform.forward).normalized);
        if (Angle > _driftStartAngle && Speed > _minimalSpeed)
        {
            if (!_isDrifting)
            {
                StartDrift();
            }
        }
        else
        {
            if(_isDrifting)
            {
                EndDrift();
            }
        }
    }

    private void EndDrift()
    {
        OnDriftEnd.Invoke();
        _isDrifting = false;
        StartCoroutine(WaitFotScoringEnd(_scoringDelay));
    }

    private void StartDrift()
    {
        if (!_isScoring)
        {
            OnDriftStart.Invoke();
            _isScoring = true;
        }
        _isDrifting = true;
        StopAllCoroutines();
    }

    private IEnumerator WaitFotScoringEnd(float time)
    {
        yield return new WaitForSeconds(time);
        if (!_isDrifting)
        {
            _isScoring = false;
            OnScoringEnd.Invoke();
        }
    }
}
