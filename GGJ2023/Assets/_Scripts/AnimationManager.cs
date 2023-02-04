using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthEvents))]
[RequireComponent(typeof(AttackEvents))]
[DisallowMultipleComponent]
public class AnimationManager : MonoBehaviour
{
    [SerializeField] private float deathTime;
    [SerializeField] private GameObject manure = null;
    private Animator animator;
    private HealthEvents healthEvents;
    private AttackEvents attackEvents;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Death = Animator.StringToHash("Death");

    private void Awake()
    {
        healthEvents = GetComponent<HealthEvents>();
        animator = GetComponent<Animator>();
        attackEvents = GetComponent<AttackEvents>();
    }

    private void OnEnable()
    {
        attackEvents.OnEnemyDetected += AttackAnim;
        healthEvents.OnDestroyed += DeathAnim;
    }

    private void OnDisable()
    {
        attackEvents.OnEnemyDetected -= AttackAnim;
        healthEvents.OnDestroyed -= DeathAnim;
    }

    private void AttackAnim(List<GameObject> obj)
    {        
        healthEvents.gameObject.GetComponent<Attack>().canWalk = false;
        GetComponent<moveToMainTree>().stopMove();
        animator.SetTrigger(Attack);
        healthEvents.gameObject.GetComponent<Attack>().canWalk = true;
    }

    private void DeathAnim(int obj)
    {
        healthEvents.gameObject.GetComponent<Attack>().canWalk = false;
        GetComponent<moveToMainTree>().stopMove();
        animator.SetTrigger(Death);
        StartCoroutine(InstantiateSeed());
    }

    private IEnumerator InstantiateSeed()
    {
        Destroy(gameObject, deathTime);
        yield return new WaitForSeconds(deathTime - 0.01f);
        Instantiate(manure, transform.position, Quaternion.identity);
    }
}
