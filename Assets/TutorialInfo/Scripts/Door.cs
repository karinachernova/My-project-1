using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _openHeight = 3f;  // на сколько метров подняться
    [SerializeField] private float _speed = 2f;       // метров в секунду

    private bool _isOpening;
    private float _topY;  // высота, на которой дверь остановится

    void Start()
    {
        _topY = transform.position.y + _openHeight;
    }

    void Update()
    {
        if (_isOpening && transform.position.y < _topY)
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);  // сдвигаем дверь вверх
        }
    }

    public void Open()
    {
        _isOpening = true;
        Debug.Log("Дверь открывается", this);
    }
}