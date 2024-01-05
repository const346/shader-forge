using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 1;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + _offset;
    }

    private void Update()
    {
        var t = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(_startPosition, _endPosition, t);
    }
}