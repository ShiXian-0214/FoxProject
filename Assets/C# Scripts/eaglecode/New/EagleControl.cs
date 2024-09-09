using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleControl : MonsterBaseValue
{
    [SerializeField] private AnimaCallbackSet animaCallbackSet;
    [SerializeField] private EagleAnimaControl eagleAnimaControl;
    [SerializeField] private GameObject originObject;
    [SerializeField] private float origin;
    private static bool StaticState = true;

    private void Awake()
    {
        init();
        origin = originObject.transform.position.y;
        eagleAnimaControl.AttackFunction += Attack;
        eagleAnimaControl.AttackFinish += AttackFinish;
    }
    private void Start()
    {
        if (StaticState)
        {
            animaCallbackSet.SetAnimationEvent(0, 0.5f, Move);
            animaCallbackSet.SetAnimationEvent(0,0.05f,CheckFlightAltitude);
            StaticState = false;
        }
    }
    protected override void Move()
    {
        if (face)
        {

            if (transform.position.x > leftX)
            {
                rigidbody2D.velocity = new Vector2(-speed, 0);

            }
            if (transform.position.x < leftX)
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                face = false;
            }
        }
        else
        {
            if (transform.position.x < rightX)
            {
                rigidbody2D.velocity = new Vector2(speed, 0);
            }
            if (transform.position.x > rightX)
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                face = true;
            }
        }

    }
    private void CheckFlightAltitude()
    {
        if (transform.position.y < origin)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 3);
        }
        if (transform.position.y >= origin)
        {

            gameObject.transform.position = new Vector2(transform.position.x, origin);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        }
    }
    private void Attack()
    {
        rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -speed);
    }
    private void AttackFinish()
    {
        if (transform.position.y < origin)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 10);
        }
        if (transform.position.y >= origin)
        {

            gameObject.transform.position = new Vector2(transform.position.x, origin);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        }
    }
    public override void Hurt(bool State) { }
    public override void Dead()
    {
        eagleAnimaControl.Dead();
    }
}
