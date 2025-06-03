using System;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private float _score;
    private TextMeshProUGUI _display;

    public float Score
    {
        set
        {
            _score = value;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        throw new NotImplementedException();
    }
}