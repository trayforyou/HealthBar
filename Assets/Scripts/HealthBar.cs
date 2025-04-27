using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthVisualizator
{
    [SerializeField] private Slider _slider;

    protected override void VisualiseNewValue(int newValue)
    {
        base.VisualiseNewValue(newValue);

        if (_slider.maxValue != _maxValue)
            _slider.maxValue = _maxValue;

        _slider.value = newValue;
    }
}