using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedController : MonoBehaviour
{
    public GameObject triangleSprite;
    void Start()
    {
        //Instantiate(triangleSprite,getPosition(),Quaternion.identity);
    }
    void Update()
    {
        triangleSprite.transform.position = getPosition();
    }
    Vector3 getPosition()
    {
        Vector3 lastPosition = transform.position;
        lastPosition.x = transform.position.x;
        lastPosition.y = -3.3576f;
        return lastPosition;
    }
}
