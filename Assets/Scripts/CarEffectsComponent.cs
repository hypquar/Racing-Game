using UnityEngine;

public class CarEffectsComponent : MonoBehaviour
{
    [SerializeField] private Light[] _stopLights;
    [SerializeField] private Light[] _reverseLights;
    [SerializeField] private ParticleSystem[] _tireSmokeParticles;
    [SerializeField] private TrailRenderer[] _skidmarkTrails;
    
    public void EnableDriftEffects()
    {
        foreach(var smoke in _tireSmokeParticles)
        {
            smoke.Play();
        }
        foreach(var trail in _skidmarkTrails)
        {
            trail.emitting = true;
        }
    }

    public void DisableDriftEffects()
    {
        foreach (var smoke in _tireSmokeParticles)
        {
            smoke.Stop();
        }
        foreach (var trail in _skidmarkTrails)
        {
            trail.emitting = false;
        }
    }
}
