using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootClick : MonoBehaviour
{
    public GameObject plusIcon => GameObject.Find("plusIcon");
    void Awake()
    {
        plusIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnMouseDown()
    {
        plusIcon.GetComponent<SpriteRenderer>().enabled = true;
        plusIcon.GetComponent<upgradeIconController>().activeIcon(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            plusIcon.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
