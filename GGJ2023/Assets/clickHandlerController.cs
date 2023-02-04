using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickHandlerController : MonoBehaviour
{
    private LayerMask targetLayer;
    Vector3 mousePos;
    void Start()
    {
        targetLayer = LayerMask.GetMask("Draggable");
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().material = null;
    }
    void OnMouseDrag()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 15));
        mousePos.z = transform.position.z;
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        
    }
}
