using System.Collections;
using UnityEngine;

public class FrogControl : MonsterBaseValue
{
    [Header("frogControlValue")]
    [SerializeField] private float speed;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] public bool isJump;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask Ground;
    [Header("frogAnimaControl")]
    [SerializeField] private AnimaControl animaControl;
    [SerializeField] private AnimaCallbackSet animaCallbackSet;
    private static bool StaticState = true;

    private void Awake()
    {
        init();
    }
    private void Start()
    {
        if(StaticState)
        {
            animaCallbackSet.SetAnimationEvent(0, 0.5f, Move);
            StaticState=false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player") 
        {
            collider2D.GetComponent<HpSystem>()?.Attack(damage);
            animaControl.Attack(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player") 
        {
            animaControl.Attack(false);
        }
    }
    protected override void Move()
    {
        if (face)
        {
            if (transform.position.x > leftX && circleCollider2D.IsTouchingLayers(Ground))
            {
                animaControl.Jump(true);
                rigidbody2D.velocity = new Vector2(-speed, jumpForce);
            }
            if (transform.position.x < leftX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                face = false;
            }
        }
        else
        {
            if (transform.position.x < rightX && circleCollider2D.IsTouchingLayers(Ground))
            {
                animaControl.Jump(true);
                rigidbody2D.velocity = new Vector2(speed, jumpForce);
            }
            if (transform.position.x > rightX)
            {
                transform.localScale = new Vector3(1, 1, 1);
                face = true;
            }
        }
    }
    public override void Dead()
    {
        animaControl.Dead();
    }


}
