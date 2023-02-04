using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseController : MonoBehaviour
{
    public GameObject[] phases;

    public void upgradePhase(int currentPhase,GameObject root)
    {
        Instantiate(phases[currentPhase+1],root.transform.position,Quaternion.identity);
    }
}
