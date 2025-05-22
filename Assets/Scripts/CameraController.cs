using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private Rigidbody _playerRb;

    private void Awake()
    {
        _playerRb = _player.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        Vector3 _playerForward = (_playerRb.linearVelocity + _player.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position, _player.position + _player.transform.TransformVector(_offset) + _playerForward * (-5f), _speed * Time.deltaTime);
        transform.LookAt(_player);
    }
}
