using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangerHealthState : MonoBehaviour
{
    [SerializeField, Min(1)] private int _points;
    [SerializeField] private Button _button;

    public event Action<int> Pressed;

    private void OnEnable() =>
        _button.onClick.AddListener(SendPoints);

    private void OnDisable() =>
        _button.onClick.RemoveListener(SendPoints);

    private void SendPoints() =>
        Pressed?.Invoke(_points);
}