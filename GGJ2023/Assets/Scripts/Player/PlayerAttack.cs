using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackEvents))]
[DisallowMultipleComponent]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int playerDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject rangeDetector;
    private AttackEvents playerEvents;
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        
        List<GameObject> detectedObjects = HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
            Vector3.left, attackRange, enemyLayer);
        
        if(detectedObjects == null) return;
        playerEvents.CallEnemyDetected(detectedObjects);
        DealDamage(detectedObjects);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rangeDetector.transform.position, Vector3.left);
    }

    private void DealDamage(List<GameObject> objects)
    {
        if (objects.Count == 0) return;
        
        foreach (var obj in objects)
        {
            Health health = obj.GetComponent<Health>();
            if(health == null) continue;
            health.TakeDamage(playerDamage);
        }
    }
}
