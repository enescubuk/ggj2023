using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float smoothTime = 0.3f;

    private float horizontalVelocity = 0.0f;
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontalInput * speed * Time.deltaTime;

        float smoothHorizontal = Mathf.SmoothDamp(transform.position.x, transform.position.x + horizontalInput * speed * Time.deltaTime, ref horizontalVelocity, smoothTime);
        transform.position = new Vector3(smoothHorizontal, transform.position.y, transform.position.z);
    }
}
