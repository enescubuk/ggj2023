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
        targetLayer = LayerMask.GetMask("Roots");
    }

    void Update()
    {
        Debug.DrawLine(transform.position + transform.right * -1 * rayDistance, transform.position + transform.right *rayDistance,Color.red);
        detectedObjects = new List<GameObject>();
        detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(transform.position,transform.right * -1,rayDistance,targetLayer));
        detectedObjects.AddRange(HelperUtilities.GetRaycastHitObjects(transform.position,transform.right,rayDistance,targetLayer));

        if (detectedObjects.Count != 0)
        {
            GetComponent<moveToMainTree>().stopMove();
        }
        else
        {
            GetComponent<moveToMainTree>().countinueMove();
        }
    }

}
