using System.Collections.Generic;
using UnityEngine;

public static class HelperUtilities
{
    public static List<GameObject> GetRaycastHitObjects(Vector3 from, Vector3 to, float length, LayerMask hitLayer)
    {
        Ray ray = new Ray(from, to);
        RaycastHit[] raycastHit = Physics.RaycastAll(ray, length, hitLayer);

        if (raycastHit.Length == 0) return null;
        List<GameObject> objects = new List<GameObject>();
        
        foreach (var obj in raycastHit)
        {
            objects.Add(obj.transform.gameObject);  
        }

        return objects;
    }
}
