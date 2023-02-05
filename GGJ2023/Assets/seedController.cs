using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedController : MonoBehaviour
{
    public GameObject triangleSprite;
    [SerializeField] private float positionY;
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
        lastPosition.y = positionY;
        return lastPosition;
    }
}
