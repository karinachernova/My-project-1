using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private bool _finished;

    void OnTriggerEnter(Collider other)
    {
        if (_finished) return;

        if (other.TryGetComponent(out ThirdPersonController player))
        {
            _finished = true;
            Debug.Log($"Уровень пройден за {Time.timeSinceLevelLoad:F1} с");
        }
    }
}