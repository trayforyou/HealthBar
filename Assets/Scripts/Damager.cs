using System;
using UnityEngine;
using UnityEngine.UI;

public class Damager : MonoBehaviour
{
    [SerializeField, Min(1)] private int _points;
    [SerializeField] private Button _button;

    public event Action<int> Damaged;

    private void OnEnable() =>
        _button.onClick.AddListener(GiveDamage);

    private void OnDisable() =>
        _button.onClick.RemoveListener(GiveDamage);

    private void GiveDamage() =>
        Damaged?.Invoke(_points);
}