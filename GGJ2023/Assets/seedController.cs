using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedController : MonoBehaviour
{
    public GameObject triangleSprite;
    void Update()
    {
        Vector3 lastPosition = triangleSprite.transform.position;
        lastPosition.x = transform.position.x;
        triangleSprite.transform.position = lastPosition;
    }
}
