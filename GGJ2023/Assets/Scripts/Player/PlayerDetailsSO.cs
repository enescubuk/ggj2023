using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetails", menuName = "Player/PlayerDetails")]
public class PlayerDetailsSO : ScriptableObject
{
    public int leafToAdd;
    public int attackRangeRadius;
    public int plantAreaRadius;
    public GameObject leafObject;
    public Vector3 leafSpawnDistanceMax;
}
