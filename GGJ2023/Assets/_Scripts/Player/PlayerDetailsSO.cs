using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetails", menuName = "Player/PlayerDetails")]
public class PlayerDetailsSO : ScriptableObject
{
    #region HEADER Attack

    [Header("Attack")]

    #endregion
    public int playerDamage;
    public float attackRangeRadius;
    public float attackInterval;
    public LayerMask enemyLayer;
    public GameObject rangeDetector;
    public int leafToAdd;

    public int plantAreaRadius;
    public GameObject leafObject;
    public Vector3 leafSpawnDistanceMax;
}