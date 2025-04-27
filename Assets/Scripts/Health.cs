using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _curentValue;

    private int _maxHealth;

    public event Action<int> StateChanged;

    public void Awake()
    {
        StateChanged?.Invoke(_curentValue);

        _maxHealth = _curentValue;
    }

    public void GiveHeal(int healPoints)
    {
        int _tempValue = 0;
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
        damagePoints = CheckCorrectNumber(damagePoints);

        int _tempValue = 0;
        _tempValue = _curentValue - damagePoints;

        if (_tempValue <= 0)
        {
            _curentValue = 0;

            StateChanged?.Invoke(_curentValue);
        }
        else
        {
            _curentValue = _tempValue;

            StateChanged?.Invoke(_curentValue);
        }
    }

    private int CheckCorrectNumber(int number)
    {
        if (number < 0)
            number = 0;

        return number;
    }
}