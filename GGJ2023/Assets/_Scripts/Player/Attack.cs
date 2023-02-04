using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackEvents))]
[DisallowMultipleComponent]
public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject rangeDetector;
    public List<GameObject> detectedObjects;
    private AttackEvents attackEvents;
    private Player player;
    private Enemy enemy;
    private bool isAttacking = false;
    private CharacterType charType;
    public bool canWalk = true;

    private void Awake()
    {
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
        attackEvents = GetComponent<AttackEvents>();
        charType = GetCharacterType();
    }

    private void Update()
    {
        detectedObjects = new List<GameObject>();
        Debug.DrawRay(rangeDetector.transform.position, rangeDetector.transform.right);
        
        if(charType == CharacterType.Player)
        {
            detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
                Vector3.left, player.playerDetails.attackRangeRadius, player.playerDetails.enemyLayer));

            detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
                Vector3.right,
                player.playerDetails.attackRangeRadius, player.playerDetails.enemyLayer));
        }
        else if (charType == CharacterType.Enemy)
        {
            detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
                Vector3.left, enemy.enemyDetails.attackRangeRadius, enemy.enemyDetails.enemyLayer));

            detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(rangeDetector.transform.position,
                Vector3.right,
                enemy.enemyDetails.attackRangeRadius, enemy.enemyDetails.enemyLayer));
        }

        if (detectedObjects.Count == 0 && canWalk)
        {
            attackEvents.CallAttackStop();
            return;
        }

        if (!isAttacking)
        {
            StartCoroutine(DealDamage(detectedObjects));
        }
    }

    private IEnumerator DealDamage(List<GameObject> objects)
    {
        attackEvents.CallEnemyDetected(detectedObjects);
        isAttacking = true;
        foreach (var obj in objects)
        {
            Health health = obj.GetComponent<Health>();
            if (health == null) continue;
            if (charType == CharacterType.Player)
            {
                health.TakeDamage(player.playerDetails.playerDamage);
                yield return new WaitForSeconds(player.playerDetails.attackInterval);
            }
            else if (charType == CharacterType.Enemy)
            {
                health.TakeDamage(enemy.enemyDetails.enemyDamage);
                yield return new WaitForSeconds(enemy.enemyDetails.attackInterval);
            }
        }

        isAttacking = false;
    }

    private CharacterType GetCharacterType()
    {
        if (player != null) return CharacterType.Player;
        else if (enemy != null) return CharacterType.Enemy;
        return CharacterType.Other;
    }
}
