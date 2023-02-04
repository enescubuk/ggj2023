using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manureConvertRoot : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ground")
        {
            Debug.Log("root ol");
            //dönüşme kodu
        }
    }
}
