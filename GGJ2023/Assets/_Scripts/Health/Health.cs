using System;
using UnityEngine;

[RequireComponent(typeof(HealthEvents))]
[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int startHealth;
    private int currentHealth;
    private HealthEvents healthEvents;
    private bool isDamageable = true;

    private void Awake()
    {
        healthEvents = GetComponent<HealthEvents>();

        currentHealth = startHealth;
    }

    public void IncreaseHealth(int health)
    {
        currentHealth += health;
    }
    
    public int GetStartHealth()
    {
        return startHealth;
    }
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isDamageable) return;
        
        currentHealth -= damage;
        float healthPercent = (float)currentHealth / (float)startHealth;

        healthEvents.CallHealthChanged(healthPercent, currentHealth, damage);

        if (healthBar != null)
        {
            healthBar.SetBarValue(healthPercent);
        }
    }
}