using UnityEngine;

public class HealthVisualizator : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected bool _isSetMaxValue;
    protected int _maxValue;

    private void Awake() =>
        _isSetMaxValue = false;

    private void OnEnable() =>
        _health.StateChanged += VisualiseNewValue;

    private void OnDisable() =>
        _health.StateChanged -= VisualiseNewValue;

    protected virtual void VisualiseNewValue(int newValue)
    {
        if (!_isSetMaxValue)
        {
            _maxValue = newValue;
            _isSetMaxValue = true;
        }
    }
}
