using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthEvents))]
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [HideInInspector] public Health health;
    [HideInInspector] public HealthEvents healthEvents;

    private void Awake()
    {
        health = GetComponent<Health>();
        healthEvents = GetComponent<HealthEvents>();
    }
    
    private void OnEnable()
    {
        healthEvents.OnHealthChanged += HandleOnHealthChangedEvent;
    }

    private void OnDisable()
    {
        healthEvents.OnHealthChanged -= HandleOnHealthChangedEvent;
    }
    
    private void HandleOnHealthChangedEvent(float healthPercent, int healthAmount, int damage)
    {
        if (healthAmount <= 0)
        {
            PlayerDestroyed();
        }
    }

    private void PlayerDestroyed()
    {
        healthEvents.CallDestroyEvent(true, 0);
    }
}
