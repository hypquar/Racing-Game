using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "Scriptable Objects/CarData")]
public class CarData : ScriptableObject
{
    public float Speed;
    public float Braking;
    public float Nitro;
    public int Price;
    public bool IsBought;
    public string SmokeColor;
    public string RimsColor;
    public string PrefabPath;

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public string GetJson()
    {
        return JsonUtility.ToJson(this, true);
    }
}
