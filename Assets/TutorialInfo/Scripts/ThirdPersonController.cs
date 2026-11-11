using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 6f;
    [SerializeField] private float _gravity = -20f;
    [SerializeField] private float _turnSpeed = 720f;  // градусов в секунду
    [SerializeField] private Transform _cameraTransform;

    private const float GroundedVelocity = -2f;  // небольшая скорость вниз, чтобы персонаж плотно стоял на полу

    private CharacterController _controller;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private float _verticalVelocity;
    private float _speedMultiplier = 1f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Поворачиваем ввод на тот же угол, на который повернута камера: W всегда ведет от камеры
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Quaternion cameraYaw = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        Vector3 direction = cameraYaw * new Vector3(input.x, 0, input.y);

        // Плавно разворачиваем персонажа в сторону движения
        if (direction != Vector3.zero)
        {
            Quaternion target = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, _turnSpeed * Time.deltaTime);
        }

        // Прыжок и гравитация - как в контроллере от первого лица
        if (_controller.isGrounded)
        {
            _verticalVelocity = GroundedVelocity;
            if (_jumpAction.WasPressedThisFrame())
            {
                _verticalVelocity = _jumpSpeed;
            }
        }
        _verticalVelocity += _gravity * Time.deltaTime;

        Vector3 velocity = direction * _speed * _speedMultiplier;
        velocity.y = _verticalVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
    public void SetSpeedMultiplier(float multiplier)
    {
        _speedMultiplier = multiplier;
    }
}