using System;
using UnityEngine;
using UnityEngine.UI;

public class Healer : MonoBehaviour
{
    [SerializeField, Min(1)] private int _points;
    [SerializeField] private Button _button;

    public event Action<int> Healed;

    private void OnEnable() =>
        _button.onClick.AddListener(GiveHeal);

    private void OnDisable() =>
        _button.onClick.RemoveListener(GiveHeal);

    private void GiveHeal() =>
        Healed?.Invoke(_points);
}