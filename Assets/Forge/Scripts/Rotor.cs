using UnityEngine;

public class Rotor : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;

    private void Update()
    {
        transform.Rotate(_velocity * Time.deltaTime, Space.World);
    }
}