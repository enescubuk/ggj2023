using System;
using UnityEngine;

[DisallowMultipleComponent]
public class HealthEvents : MonoBehaviour
{
    public event Action<float, int, int> OnHealthChanged;
    public event Action<int> OnDestroyed;

    public void CallHealthChanged(float healthPercent, int healthAmount, int damage)
    {
        OnHealthChanged?.Invoke(healthPercent, healthAmount, damage);
    }
    
    public void CallDestroyEvent(bool isPlayerDead, int points)
    {
        OnDestroyed?.Invoke(points);
    }
}