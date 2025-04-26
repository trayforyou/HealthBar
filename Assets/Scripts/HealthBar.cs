using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private bool _isSetMaxValue;

    private void Awake() =>
        _isSetMaxValue = false;

    private void OnEnable() =>
        _health.StateChanged += ChangeSlider;

    private void OnDisable() =>
        _health.StateChanged -= ChangeSlider;

    private void ChangeSlider(int newValue)
    {
        if (!_isSetMaxValue)
        {
            _slider.maxValue = newValue;
            _isSetMaxValue = true;
        }

        _slider.value = newValue;
    }
}