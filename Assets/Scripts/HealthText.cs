using TMPro;
using UnityEngine;

public class HealthText : HealthVisualizator
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _splitter = "/";

    protected override void VisualiseNewValue(int newValue)
    {
        base.VisualiseNewValue(newValue);

        _text.text = newValue + _splitter + _maxValue;
    }
}