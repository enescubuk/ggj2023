using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dayNightCircle : MonoBehaviour
{
    private int counter = 0;
    void day()
    {
        transform.DORotate(new Vector3(90,0,0),5);
    }
    void night()
    {
        transform.DORotate(new Vector3(185,0,0),5);
    }

    public void pressButton()
    {
        counter++;
        if (counter % 2 != 0)
        {
            night();
        }
        else
        {
            day();
        }
    }
}
