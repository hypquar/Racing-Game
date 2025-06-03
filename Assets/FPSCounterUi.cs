using TMPro;
using UnityEngine;

public class FPSCounterUi : MonoBehaviour
{
    public TextMeshProUGUI fpsText;

    void Update()
    {
        float fps = 1f / Time.unscaledDeltaTime;
        fpsText.text = $"FPS: {fps:0.}";
    }
}
