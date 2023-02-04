using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails", menuName = "Enemy/Enemy Details")]
public class EnemyDetailsSO : ScriptableObject
{
    #region HEADER Attack

    [Header("Attack")]

    #endregion
    public int enemyDamage;
    public float attackRangeRadius;
    public float attackInterval;
    public LayerMask enemyLayer;
}