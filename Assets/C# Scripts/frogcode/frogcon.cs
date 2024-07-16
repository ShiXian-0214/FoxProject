using System.Collections;
using UnityEngine;

public class frogcon : MonsterBaseValue
{
    [Header("frogControlValue")]
    [SerializeField] private float speed;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] public bool isJump;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask Ground;
    [Header("frogAnimaControl")]
    [SerializeField] private AnimaControl animaControl;


    void Awake()
    {
        init();
        SetAnimationEventValue(0.5f, "Move");
        AddAnimationEvent();
    }

    protected override void Move()
    {
        if (face)
        {
            if (transform.position.x > leftX && circleCollider2D.IsTouchingLayers(Ground))
            {
                anima.SetBool("jumping", true);
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
                anima.SetBool("jumping", true);
                rigidbody2D.velocity = new Vector2(speed, jumpForce);
            }
            if (transform.position.x > rightX)
            {
                transform.localScale = new Vector3(1, 1, 1);
                face = true;
            }
        }
    }


}
