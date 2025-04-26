using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private string _splitter;
    private int _maxValue;

    private void Awake() =>
        _splitter = "/";

    private void OnEnable() =>
        _health.StateChanged += ChangeSlider;

    private void OnDisable() =>
        _health.StateChanged -= ChangeSlider;

    private void ChangeSlider(int newValue)
    {
        if(_maxValue == 0)
            _maxValue = newValue;

        _text.text = newValue + _splitter + _maxValue;
    }
}