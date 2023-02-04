using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRay : MonoBehaviour
{
    public List<GameObject> detectedObjects;
    public float rayDistance;
    private LayerMask targetLayer ;
    void Awake()
    {
        targetLayer = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        
    }
}
