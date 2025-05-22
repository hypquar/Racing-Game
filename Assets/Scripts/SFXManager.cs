using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource _car;

    [SerializeField] private AudioClip _lowRpm;
    [SerializeField] private AudioClip _midRpm;
    [SerializeField] private AudioClip _highRpm;

   public void PlayRpm(int index)
    {
        switch(index)
        {
            case 0:
                _car.PlayOneShot(_lowRpm);
                break;
            case 1:
                _car.PlayOneShot(_midRpm);
                break;
            case 2:
                _car.PlayOneShot(_highRpm);
                break;
            default:
                _car.PlayOneShot(_lowRpm);
                break;
        }
    }
}
