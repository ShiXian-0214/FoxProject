using UnityEngine;

public abstract class MonsterBaseValue : MonoBehaviour
{
    [Header("BaseElement")]
    [SerializeField] protected Animator anima = null;
    [SerializeField] protected Rigidbody2D rigidbody2D = null;

    [Header("CoordinateValue")]
    [SerializeField] protected Transform leftPoint = null;
    [SerializeField] protected Transform rightPoint = null;
    [SerializeField] protected float leftX;
    [SerializeField] protected float rightX;
    [Header("FaceDirection")]
    [SerializeField] protected bool face = true;
    [Header("AnimaBool")]
    [SerializeField] protected bool isAttack;
    [Header("AnimaEvent")]
    [SerializeField] protected AnimationClip animationClip = null;
    [SerializeField] protected AnimationEvent animationEvent = new AnimationEvent();
    protected void init()
    {
        leftX = leftPoint.transform.position.x;
        rightX = rightPoint.transform.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    protected abstract void Move();
    protected void SetAnimationEventValue(float triggerTime , string functionName)
    {
        animationEvent.time = triggerTime;
        animationEvent.functionName = functionName;
    }
    protected void AddAnimationEvent()
    {
        if (animationClip.events.Length==0)
        {
            animationClip.AddEvent(animationEvent);  
        }
        else
        {
            return;
        }
    }


}
