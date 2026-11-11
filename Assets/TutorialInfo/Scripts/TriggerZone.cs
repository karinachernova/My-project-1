using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"В зону вошел: {other.name}");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"Из зоны вышел: {other.name}");
    }
}