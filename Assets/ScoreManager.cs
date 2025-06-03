using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private LevelManager _level;
    [SerializeField] private TextMeshProUGUI _display;

    [SerializeField] private float _driftFactor;

    public void StartScoring()
    {
        InvokeRepeating("ResolveScore", 0f, 1f);
    }

    public void StopScoring()
    {
        CancelInvoke("ResolveScore");
    }

    private void ResolveScore()
    {
        _score += _driftFactor;
        _display.text = _score.ToString("0.");
    }
}