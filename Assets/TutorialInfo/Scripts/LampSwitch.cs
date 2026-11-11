using UnityEngine;
using UnityEngine.InputSystem;

public class LampSwitch : MonoBehaviour
{
    private Light _lamp;

    void Start()
    {
        // Находим компонент Light на этом же объекте и запоминаем его
        _lamp = GetComponent<Light>();
    }

    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            _lamp.enabled = !_lamp.enabled;
            Debug.Log(_lamp.enabled ? "Свет включен" : "Свет выключен");
        }
    }
}