using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaControl : MonoBehaviour,IAnimaControl
{
    [SerializeField] Animator animator = null;
    [SerializeField] Rigidbody2D rigidBody2D = null;
    [SerializeField] CircleCollider2D circleCollider2D = null;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private AnimaCallbackSet animaCallbackSet;
    private static bool StaticState = true;
    private void Start()
    {
        if (StaticState)
        {
            animaCallbackSet.SetAnimationEvent(1, 0.0167f, JumpFinish);
            animaCallbackSet.SetAnimationEvent(2, 0.0167f, fallingFinish);
            animaCallbackSet.SetAnimationEvent(3, 0.4167f, DeadFinish);
            StaticState = false;
        }
        else
        {
            return;
        }


    }
    public void Jump(bool State)
    {
        if (State)
        {
            animator.SetBool("jumping", true);
        }
    }
    public void Attack(bool State)
    {
        animator.SetBool("attack",State);
    }
    public void Dead()
    {
        animator.SetTrigger("death");
    }
    private void JumpFinish()
    {
        if (rigidBody2D.velocity.y < 0)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
    }
    private void fallingFinish()
    {
        if (circleCollider2D.IsTouchingLayers(Ground) && animator.GetBool("falling"))
        {
            animator.SetBool("falling", false);
        }
    }
    private void DeadFinish()
    {
        Destroy(gameObject);
        AudioManager.instance.PlayOneShot(FModEvents.instance.enemyDie, this.transform.position);
    }

}
