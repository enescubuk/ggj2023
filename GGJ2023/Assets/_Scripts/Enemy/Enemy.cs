using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthEvents))]
[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    public EnemyDetailsSO enemyDetails;
    [SerializeField] private int enemyKillPoint;
    private HealthEvents healthEvents;
    private Health health;

    private void Awake()
    {
        healthEvents = GetComponent<HealthEvents>();
        health = GetComponent<Health>();
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
            EnemyDestroyed();
        }
    }

    private void EnemyDestroyed()
    {
        healthEvents.CallDestroyEvent(false, enemyKillPoint);
    }
}
