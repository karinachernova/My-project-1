using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _speed = 90f;          // градусов в секунду
    [SerializeField] private Vector3 _axis = Vector3.up;  // ось вращения

    void Update()
    {
        transform.Rotate(_axis * _speed * Time.deltaTime);
    }
}