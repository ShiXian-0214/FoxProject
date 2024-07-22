using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimaCallbackSet : MonoBehaviour
{
    [SerializeField] private List<AnimationClip> animationClips;
    private List<AnimationEvent> animationEvents = new List<AnimationEvent>();
    private AnimationEvent animationEvent;
    private void Awake()
    {
        if (animationEvents.Count == 0)
        {
            for (int i = 0; i < animationClips.Count; i++)
            {
                animationEvents.Add(animationEvent = new AnimationEvent());
            }
        }
    }
    public void SetAnimationEventValue(int ClipNumber, float triggerTime, Action function)//
    {
        animationEvents[ClipNumber].time = triggerTime;
        animationEvents[ClipNumber].functionName = function.Method.Name;
        AddEvent(ClipNumber); 
    }
    private void AddEvent(int ClipNumber)
    {
        animationClips[ClipNumber].AddEvent(animationEvents[ClipNumber]);
    }

}
