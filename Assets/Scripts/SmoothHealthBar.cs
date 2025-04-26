using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smooth;

    private int _healthValue;

    private void OnEnable() =>
        _health.StateChanged += ChangeHealthValue;

    private void OnDisable() =>
        _health.StateChanged -= ChangeHealthValue;

    private void FixedUpdate()
    {
        if (_slider.value != _healthValue)
            _slider.value = Mathf.MoveTowards(_slider.value, _healthValue, _smooth);
    }

    private void ChangeHealthValue(int newValue)
    {
        if(_healthValue == 0)
            _slider.maxValue = newValue;

        _healthValue = newValue;
    }
    
}
