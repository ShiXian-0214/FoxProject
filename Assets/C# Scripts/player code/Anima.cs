using System;
using System.Reflection;
using UnityEngine;

public class Anima : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Animator animator;
    [SerializeField] private AnimaCallbackSet animaCallbackSet;

    public event Action RestJumpCount;
    public event Action RestAttackCount;

    private void Start()
    {
        animaCallbackSet.SetAnimationEvent(0, 0.0167f, () => CheckFall());
        animaCallbackSet.SetAnimationEvent(1, 0.0167f, () => FallingFinish());
        animaCallbackSet.SetAnimationEvent(2, 0.167f, () => AttackFinish());

    }
    public void Move()
    {
        animator.SetFloat("runing", Mathf.Abs(rigidbody2D.velocity.x));
    }

    public void Jump(bool Jump)
    {
        animator.SetBool("jumping", Jump);
    }
    public void Crouch(bool crouchPressed)
    {
        animator.SetBool("Crouch", crouchPressed);
    }
    public void StairsStop(bool stairsState)
    {
        RestValueAndAnimaState();
        if (stairsState)
        {
            animator.SetBool("StairsStop", stairsState);
        }
        else
        {
            animator.SetBool("StairsStop", stairsState);
        }
    }
    public void StairsMove(bool stairsState)
    {
        if (stairsState)
        {
            animator.SetBool("StairsMove", stairsState);
        }
        else
        {
            animator.SetBool("StairsMove", stairsState);
        }
    }
    public void Attack()
    {
        animator.SetBool("Attack", true);
    }
    private void RestValueAndAnimaState()
    {
        animator.Rebind();
        RestJumpCount.Invoke();
        RestAttackCount.Invoke();

    }

    private void CheckFall()
    {
        if (rigidbody2D.velocity.y < -0.1f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
    }
    private void FallingFinish()
    {
        if (circleCollider2D.IsTouchingLayers(layerMask))
        {
            animator.SetBool("falling", false);
            RestJumpCount.Invoke();
        }
    }
    private void AttackFinish()
    {
        animator.SetBool("Attack", false);
        RestAttackCount.Invoke();
    }
}
