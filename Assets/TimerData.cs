using UnityEngine;

[CreateAssetMenu(fileName = "TimerData", menuName = "ScriptableObject/New Timer Data")]
public class TimerData : ScriptableObject
{
    public float Time;
    public float Increment;
}