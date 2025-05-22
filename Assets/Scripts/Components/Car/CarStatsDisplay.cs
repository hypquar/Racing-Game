using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarStatsDisplay : MonoBehaviour
{
    [SerializeField] private Engine _engine;
    [SerializeField] private Transmission _transmission;
    [SerializeField] private TextMeshProUGUI _rpmDisplay;
    [SerializeField] private TextMeshProUGUI _gearDisplay;
    [SerializeField] private Dictionary<int, string> _gearIndexDisplayPair;

    private void Update()
    {
        _rpmDisplay.text = _engine.Rpm.ToString("1,000");

        foreach (var index in _gearIndexDisplayPair.Keys)
        {
            if (_transmission.CurrentGear == index)
            {
                _gearDisplay.text = _gearIndexDisplayPair[index];
            }
        }
    }
}
