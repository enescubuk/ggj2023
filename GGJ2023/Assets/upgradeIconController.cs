using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeIconController : MonoBehaviour
{
    public GameObject lastObject;

    public void activeIcon(GameObject lastObject)
    {
        this.lastObject = lastObject;
        setPosIcon(lastObject);
    }
    void setPosIcon(GameObject lastObject)
    {
        Vector3 lastPosition = lastObject.transform.position;
        lastPosition.y += 2;
        lastPosition.z = 1.731621f;
        transform.position = lastPosition;
    }

    void OnMouseDown()
    {
        Debug.Log(31);
        GameObject.FindGameObjectWithTag("PhaseManager").GetComponent<phaseController>().upgradePhase(detectPhase(),lastObject);
        Destroy(lastObject);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    int detectPhase()
    {
        if (lastObject.name.Contains("1"))
        {
            return 0;
        }
        else if(lastObject.name.Contains("2"))
        {
            return 1;
        }
        else if(lastObject.name.Contains("3"))
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }
}
