using UnityEngine;

public class Crystal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Реагируем только на объект, у которого есть компонент Collector
        if (other.TryGetComponent(out Collector collector))
        {
            collector.AddCrystal();
            Destroy(gameObject);
        }
    }
}