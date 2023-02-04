using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killit : MonoBehaviour
{
    public GameObject manure;



    public void KillIt()
    {
        spawnManure();
        //öldürmek için kod
        Destroy(this.gameObject,3f);
    }
    void spawnManure()
    {
        Instantiate(manure,transform.position,Quaternion.identity);
    }
}
