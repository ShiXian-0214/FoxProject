using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Collider")]
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private LayerMask layerMask;
    [Header("MoveValue")]
    [SerializeField] private float speed;
    [Header("JumpValue")]
    [SerializeField] private int jumpCount = 1;
    [SerializeField] private int jumpCountRest = 1;
    [SerializeField] private float jumpforce = 10.5f;
    [SerializeField] private int attackCount;
    [Header("Anima")]
    [SerializeField] private Anima anima;

    private void Awake()
    {
        anima.FallingEndRestJumpCount += RestJumpCount;
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
        if (jumpPressed)
        {
            if (jumpCount > 0)
            {
                anima.Jump(true);
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpforce);
                jumpCount--;
            }
        }
    }
    public void Attack()
    {
        if (Input.GetButtonDown("Attack") && attackCount > 0)
        {

        }
    }
    public void Crouch()
    {

    }
    private void RestJumpCount()
    {
        jumpCount = jumpCountRest;
    }




}
