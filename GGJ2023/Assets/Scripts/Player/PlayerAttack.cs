using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAttack))]
[DisallowMultipleComponent]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject rangeDetector;
    private AttackEvents playerEvents;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.X)) return;
        
        List<GameObject> detectedObjects = HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
            Vector3.left, attackRange, enemyLayer);
        
        if(detectedObjects == null) return;
        playerEvents.CallEnemyDetected(detectedObjects);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rangeDetector.transform.position, Vector3.left);
    }
}
