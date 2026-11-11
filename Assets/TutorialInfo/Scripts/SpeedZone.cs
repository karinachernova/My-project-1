using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    [SerializeField] private float _multiplier = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThirdPersonController player))
        {
            player.SetSpeedMultiplier(_multiplier);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ThirdPersonController player))
        {
            player.SetSpeedMultiplier(1f);
        }
    }
}