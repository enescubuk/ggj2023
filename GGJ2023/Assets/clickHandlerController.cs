using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickHandlerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool holdOnObject = false;
    public void OnPointerDown( PointerEventData eventData )
    {
        Debug.Log("onpointerdown");
        holdOnObject = true;
    }
    public void OnPointerUp( PointerEventData eventData )
    {
        Debug.Log("onpointerup");
        holdOnObject = false;
    }

    void Update()
    {
        //if (holdOnObject)
        //{
        //    Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = new Vector3(mouseScreenPosition.x,mouseScreenPosition.y,transform.position.z);
        //}

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(worldPosition);
    }   
}
