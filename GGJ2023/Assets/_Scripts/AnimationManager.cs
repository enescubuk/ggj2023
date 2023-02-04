using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthEvents))]
[RequireComponent(typeof(AttackEvents))]
[DisallowMultipleComponent]
public class AnimationManager : MonoBehaviour
{
    [SerializeField] private float fadeOutDuration;
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
        animator.SetTrigger(Attack);
    }

    private void DeathAnim(int obj)
    {
        animator.SetTrigger(Death);
        StartCoroutine(FadeOutObject());
    }

    private IEnumerator FadeOutObject()
    {
        for (float t = 0f; t < fadeOutDuration; t += Time.deltaTime)
        {
            float normalizedTİme = t / fadeOutDuration;
            //gameObject.GetComponent<Renderer>().material.color.a = Color.Lerp(255f, 0f, fadeOutDuration);
            yield return null;
        }
    }
}
