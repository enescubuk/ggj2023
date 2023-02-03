using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveToMainTree : MonoBehaviour
{
    private GameObject mainTree;
    private Rigidbody rigidbody => GetComponent<Rigidbody>();
    private bool canMove = false;
    void Awake()
    {
        mainTree = GameObject.FindGameObjectWithTag("MainTree");
    }
    void Start()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.x = mainTree.transform.position.x;
        transform.DOMove(targetPosition,5,false);
    }

    void Update()
    {
        
    }

}
