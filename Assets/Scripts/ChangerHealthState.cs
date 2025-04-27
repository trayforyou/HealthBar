using UnityEngine;
using UnityEngine.UI;

public abstract class ChangerHealthState : MonoBehaviour
{
    [SerializeField, Min(1)] protected int _points;
    [SerializeField] protected Health _health;
    [SerializeField] private Button _button;

    private void OnEnable() =>
        _button.onClick.AddListener(SendPoints);

    private void OnDisable() =>
        _button.onClick.RemoveListener(SendPoints);

    protected abstract void SendPoints();
}