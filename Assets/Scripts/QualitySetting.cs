using UnityEngine;

public class QualitySetting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
}
