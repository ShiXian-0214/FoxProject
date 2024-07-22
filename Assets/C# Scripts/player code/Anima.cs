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

    public event Action FallingEndRestJumpCount;

    private void Awake()
    {
        animaCallbackSet.SetAnimationEventValue(0, 0.0167f, () => CheckFall());
        animaCallbackSet.SetAnimationEventValue(1, 0.0167f, () => FallingEnd());
    }
    public void Move()
    {
        animator.SetFloat("runing", Mathf.Abs(rigidbody2D.velocity.x));
    }

    public void Jump(bool Jump)
    {
        if (Jump)
        {
            animator.SetBool("jumping", true);
        }
    }

    private void CheckFall()
    {
        animator.SetBool("falling", false);
        if (rigidbody2D.velocity.y < -0.1f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
    }
    private void FallingEnd()
    {
        if (circleCollider2D.IsTouchingLayers(layerMask))
        {
            animator.SetBool("falling", false);
            FallingEndRestJumpCount.Invoke();
        }
    }
}
