using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvents : MonoBehaviour
{
    public event Action<List<GameObject>> OnEnemyDetected;

    public void CallEnemyDetected(List<GameObject> detectedObjects)
    {
        OnEnemyDetected?.Invoke(detectedObjects);
    }
}
