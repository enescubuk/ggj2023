using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manureConvertRoot : MonoBehaviour
{
    private phaseController phaseController => GameObject.Find("PhaseManager").GetComponent<phaseController>();
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ground")
        {
            Debug.Log("root ol");
            phaseController.upgradePhase(-1,gameObject);
            Destroy(gameObject);
        }
    }
}
