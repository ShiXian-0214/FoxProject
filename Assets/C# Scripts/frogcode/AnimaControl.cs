using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaControl : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] Rigidbody2D rigidbody2D = null;
    [SerializeField] CircleCollider2D circleCollider2D = null;
    [SerializeField] private LayerMask Ground;
    private void Update()
    {
        Jump();
    }
    public void Jump()
    {
        if (animator.GetBool("jumping") == true)
        {
            if (rigidbody2D.velocity.y < 0)
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
            }
        }
        if (circleCollider2D.IsTouchingLayers(Ground) && animator.GetBool("falling"))
        {
            animator.SetBool("falling", false);
        }
    }
   
}
