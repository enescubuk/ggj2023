using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootClick : MonoBehaviour
{
    public GameObject plusIcon;
    void Awake()
    {
        setGameobject();
        plusIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

    void setGameobject()
    {
        plusIcon = GameObject.Find("plusIcon");
    }

    void OnMouseDown()
    {
        setGameobject();
        Debug.Log(1);
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
