using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _crystalsToOpen = 3;
    [SerializeField] private Door _door;

    private int _crystals;

    public void AddCrystal()
    {
        _crystals++;
        Debug.Log($"Кристаллов собрано: {_crystals} из {_crystalsToOpen}");

        if (_crystals == _crystalsToOpen)
        {
            _door.Open();
        }
    }
}