using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveToMainTree : MonoBehaviour
{
    private GameObject mainTree;
    private AttackEvents attackEvents;
    private Rigidbody rigidbody => GetComponent<Rigidbody>();
    private bool canMove = false;
    void Awake()
    {
        attackEvents = GetComponent<AttackEvents>();
        mainTree = GameObject.FindGameObjectWithTag("MainTree");
    }

    private void OnEnable()
    {
        attackEvents.OnAttackStop += countinueMove;
    }

    private void OnDisable()
    {
        attackEvents.OnAttackStop -= countinueMove;
    }

    void Start()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.x = mainTree.transform.position.x;
        transform.DOMove(targetPosition,10,false);
    }

    public void stopMove()
    {
        DOTween.Pause(transform);
    }
    public void countinueMove()
    {
        Debug.Log("123");
        DOTween.Play(transform);
    }

}
