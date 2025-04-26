using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _curentValue;
    [SerializeField] private Healer _healer;
    [SerializeField] private Damager _damager;

    private int _maxHealth;
    private int _tempValue;

    public event Action<int> StateChanged;
    public event Action Died;

    public void Awake()
    {
        StateChanged?.Invoke(_curentValue);

        _maxHealth = _curentValue;
    }

    private void OnEnable()
    {
        _healer.Healed += GiveHeal;
        _damager.Damaged += GiveDamage;
    }

    private void OnDisable()
    {
        _healer.Healed -= GiveHeal;
        _damager.Damaged -= GiveDamage;
    }

    public void GiveHeal(int healPoints)
    {
        _tempValue = 0;
        _tempValue = _curentValue + healPoints;

        if (_tempValue <= _maxHealth)
        {
            _curentValue = _tempValue;

            StateChanged?.Invoke(_curentValue);
        }
        else
        {
            _curentValue = _maxHealth;

            StateChanged?.Invoke(_curentValue);
        }
    }

    public void GiveDamage(int damagePoints)
    {
        _tempValue = 0;
        _tempValue = _curentValue - damagePoints;

        if (_tempValue <= 0)
        {
            _curentValue = 0;

            StateChanged?.Invoke(_curentValue);

            Die();
        }
        else
        {
            _curentValue = _tempValue;

            StateChanged?.Invoke(_curentValue);
        }
    }

    private void Die()
    {
        Died?.Invoke();

        OnDisable();
    }
}