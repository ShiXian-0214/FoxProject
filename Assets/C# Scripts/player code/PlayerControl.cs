using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour, IPlayer, IHpSystem
{
    [Header("Collider")]
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Rigidbody2D rigidBody2D;
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
    [SerializeField] private float damage = 1;
    [Header("Anima")]
    [SerializeField] private Anima anima;
    [Header("State")]
    [SerializeField] private bool isAttack;
    [SerializeField] private bool onStairs;
    private bool injuredStiff;
    private bool monsterDirection; // right = true，Left = false
    private void Awake()
    {
        anima.RestJumpCount += RestJumpCount;
        anima.RestAttackCount += RestAttackCount;
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        switch (collision2D.gameObject.tag)
        {
            case "Enemy":
                if (collision2D.gameObject.transform.position.x > this.gameObject.transform.position.x)
                {
                    monsterDirection = true;
                }
                else
                {
                    monsterDirection = false;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        switch (collider2D.tag)
        {
            case "Enemy":
                if (isAttack)
                {
                    collider2D.gameObject.GetComponent<HpSystem>()?.Attack(damage);
                }
                break;
            case "stairs":
                onStairs = true;
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                anima.StairsStop(true);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        switch (collider2D.tag)
        {
            case "stairs":
                onStairs = false;
                rigidBody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                anima.StairsStop(false);
                anima.StairsMove(false);
                break;
        }
    }
    public void Move(float movePressed)
    {
        if (injuredStiff)
        {
            if (monsterDirection)
            {
                rigidBody2D.velocity = new Vector2(-speed, rigidBody2D.velocity.y);
            }
            else
            {
                rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
            }
        }
        else
        {
            anima.Move();
            rigidBody2D.velocity = new Vector2(movePressed * speed, rigidBody2D.velocity.y);
            if (movePressed != 0)
            {
                transform.localScale = new Vector3(movePressed, 1, 1);
            }
        }
    }
    public void Jump(bool jumpPressed)
    {
        if (jumpPressed && !onStairs)
        {
            if (jumpCount > 0 && !injuredStiff)
            {
                anima.Jump(jumpPressed);
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
                jumpCount--;
            }
        }
    }
    public void CrouchAndStairsDown(bool crouchPressed)
    {
        bool checkGroundInUp = Physics2D.OverlapCircle(crouchLayerCheck.position, 0.02f, layerMask);
        if (crouchPressed && !onStairs)
        {
            anima.Crouch(true);
            boxCollider2D.enabled = false;
        }
        else if (crouchPressed && onStairs)
        {
            rigidBody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, -speed);
            anima.StairsMove(true);
        }
        else if (!crouchPressed && onStairs)
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
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
        if (StairsUpPressed && onStairs)
        {
            rigidBody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, speed);
            anima.StairsMove(true);
        }
    }
    public void Attack(bool attackPressed)
    {
        if (attackPressed && !onStairs)
        {
            if (attackCount > 0)
            {
                isAttack = true;
                anima.Attack();
                attackCount--;
            }
        }
    }

    public void Hurt(bool State)
    {
        if (State)
        {
            injuredStiff = true;
            anima.Hurt(true);
        }
        else
        {
            injuredStiff = false;
            anima.Hurt(false);
        }
    }
    public void Dead()
    {
        //SceneManager.LoadScene("Dead Scene");
        //AudioManager.instance.PlayOneShot(FModEvents.instance.deadEvent, this.transform.position);
    }

    private void RestJumpCount()
    {
        jumpCount = jumpCountRest;
    }
    private void RestAttackCount()
    {
        attackCount = attackRest;
        isAttack = false;
    }




}
