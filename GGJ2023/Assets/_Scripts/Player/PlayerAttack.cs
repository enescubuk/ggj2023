using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackEvents))]
[DisallowMultipleComponent]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject rangeDetector;
    public List<GameObject> detectedObjects;
    private AttackEvents playerEvents;
    private Player player;
    private bool isAttacking = false;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        detectedObjects = new List<GameObject>();
        Debug.DrawRay(rangeDetector.transform.position, rangeDetector.transform.right);

        detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
            Vector3.left, player.playerDetails.attackRangeRadius, player.playerDetails.enemyLayer));

        detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position, Vector3.right,
            player.playerDetails.attackRangeRadius, player.playerDetails.enemyLayer));

        if (detectedObjects.Count == 0) return;
        //playerEvents.CallEnemyDetected(detectedObjects);

        if (!isAttacking)
        {
            StartCoroutine(DealDamage(detectedObjects));
        }
    }

    private IEnumerator DealDamage(List<GameObject> objects)
    {
        isAttacking = true;
        foreach (var obj in objects)
        {
            Health health = obj.GetComponent<Health>();
            if (health == null) continue;
            health.TakeDamage(player.playerDetails.playerDamage);
            yield return new WaitForSeconds(player.playerDetails.attackInterval);
        }

        isAttacking = false;
    }
}