using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed;
    private Vector3 nextPos;
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        nextPos = transform.right * h * speed + transform.position;
        transform.position = Vector3.Lerp(transform.position,nextPos,1 * Time.deltaTime);
    }
}
