using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Scriptable Objects/LevelSetting")]
public class LevelSetting : ScriptableObject
{
    public float OneStarPoints;
    public float TwoStarsPoints;
    public float ThreeStarsPoints;
    public float ScoreDelay;
}