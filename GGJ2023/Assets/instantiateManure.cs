using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class instantiateManure : MonoBehaviour , IPointerClickHandler
{
    public GameObject manure;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameObject instantiated = Instantiate(manure, new Vector3(getMousePosition().x, getMousePosition().y, 0f),Quaternion.identity);
        instantiated.GetComponent<Rigidbody>().isKinematic = true;
        instantiated.GetComponent<Collider>().material = null;
    }

    Vector3 getMousePosition()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 15));
        mousePos.z = 2.24f;
        return mousePos;
    }

    
}
