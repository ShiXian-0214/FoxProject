using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAnimaControl : MonoBehaviour,IAnimaControl
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimaCallbackSet animaCallbackSet;
    public event Action AttackFunction;
    public event Action AttackFinish;
    private static bool StaticState = true;
    private void Awake()
    {
        if (StaticState)
        {
            animaCallbackSet.SetAnimationEvent(1, 0.4167f, DeadFinish);
        }
    }
    public void Attack(bool State)
    {
        if (State)
        {
            animator.SetBool("attack", true);
            AttackFunction.Invoke();
            AudioManager.instance.PlayOneShot(FModEvents.instance.eagleAttackEvent, this.transform.position);
        }
        else 
        {
            animator.SetBool("attack", false);
        }
    }
    public void Dead()
    {
        animator.SetTrigger("death");
    }
    private void DeadFinish()
    {
        Destroy(gameObject);
        AudioManager.instance.PlayOneShot(FModEvents.instance.enemyDie, this.transform.position);
    }
}
