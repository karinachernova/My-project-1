using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThirdPersonController player))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}