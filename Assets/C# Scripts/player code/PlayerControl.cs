using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IPlayer
{
    [Header("Collider")]
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform crouchLayerCheck;
    [SerializeField] private LayerMask layerMask;
    [Header("MoveValue")]
    [SerializeField] private float speed;
    [Header("JumpValue")]
    [SerializeField] private int jumpCount = 1;
    [SerializeField] private int jumpCountRest = 1;
    [SerializeField] private float jumpForce = 10.5f;
    [Header("attackValue")]
    [SerializeField] private int attackCount;
    [SerializeField] private int attackRest;
    [Header("Anima")]
    [SerializeField] private Anima anima;

    [SerializeField] private bool OnStairs;

    private void Awake()
    {
        anima.RestJumpCount += RestJumpCount;
        anima.AttackFinishRestAttackCount += RestAttackCount;
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        switch (collider2D.tag)
        {
            case "stairs":
                OnStairs = true;
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                anima.StairsStop(true);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        switch (collider2D.tag)
        {
            case "stairs":
                OnStairs = false;
                rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                anima.StairsStop(false);
                anima.StairsMove(false);
                break;
        }
    }
    public void Move(float movePressed)
    {
        anima.Move();
        rigidbody2D.velocity = new Vector2(movePressed * speed, rigidbody2D.velocity.y);
        if (movePressed != 0)
        {
            transform.localScale = new Vector3(movePressed, 1, 1);
        }
    }
    public void Jump(bool jumpPressed)
    {
        if (jumpPressed&&!OnStairs)
        {
            if (jumpCount > 0)
            {
                anima.Jump(jumpPressed);
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                jumpCount--;
            }
        }
    }
    public void CrouchAndStairsDown(bool crouchPressed)
    {
        bool checkGroundInUp = Physics2D.OverlapCircle(crouchLayerCheck.position, 0.02f, layerMask);
        if (crouchPressed && !OnStairs)
        {
            anima.Crouch(true);
            boxCollider2D.enabled = false;
        }
        else if (crouchPressed && OnStairs)
        {
            rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -speed);
            anima.StairsMove(true);
        }
        else if (!crouchPressed && OnStairs)
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            anima.StairsMove(false);
        }
        else
        {
            if (checkGroundInUp)
            {
                anima.Crouch(true);
            }
            else
            {
                anima.Crouch(false);
                boxCollider2D.enabled = true;
            }
        }
    }
    public void StairsUp(bool StairsUpPressed)
    {
        if (StairsUpPressed && OnStairs)
        {
            rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed);
            anima.StairsMove(true);
        }
    }
    public void Attack(bool attackPressed)
    {
        if (attackPressed)
        {
            if (attackCount > 0)
            {
                anima.Attack();
                attackCount--;
            }
        }

    }

    private void RestJumpCount()
    {
        jumpCount = jumpCountRest;
    }
    private void RestAttackCount()
    {
        attackCount = attackRest;
    }




}
