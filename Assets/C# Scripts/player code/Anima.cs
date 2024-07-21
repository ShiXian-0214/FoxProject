using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Anima : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Animator animator;
    [SerializeField] private List<AnimationClip> animationClips;
    [SerializeField] private List<AnimationEvent> animationEvents;

    public event Action FallingEndRestJumpCount;

    private void Awake()
    {
        SetAnimationEventValue(0, 0.0167f, CheckFall());
        SetAnimationEventValue(1, 0.0167f, FallingEnd());
        int eventIndex = 0;
        foreach (var Clip in animationClips)
        {
            if (eventIndex < animationEvents.Count)
            {
                Clip.AddEvent(animationEvents[eventIndex]);
                eventIndex++;
            }

        }
    }
    void SetAnimationEventValue(int EventNumber, float triggerTime, string functionName)//
    {
        animationEvents[EventNumber].time = triggerTime;
        animationEvents[EventNumber].functionName = functionName;
    }

    public void Jump(bool Jump)
    {
        if (Jump)
        {
            animator.SetBool("jumping", true);
        }
    }

    private string CheckFall()
    {
        animator.SetBool("falling", false);
        if (rigidbody2D.velocity.y < -0.1f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
        return MethodBase.GetCurrentMethod().Name;
    }
    private string FallingEnd()
    {
        if (circleCollider2D.IsTouchingLayers(layerMask))
        {
            animator.SetBool("falling", false);
            FallingEndRestJumpCount.Invoke();
        }
        return MethodBase.GetCurrentMethod().Name;
    }
}
