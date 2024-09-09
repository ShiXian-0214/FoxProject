using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evemy_frog_value : MonoBehaviour
{
    [Header("基礎元件")]
    public Animator anime;
    public Rigidbody2D rb;
    public CircleCollider2D cd;
    public LayerMask Ground;
    [Header("跳躍係數")]
    public float jumpforce;
    [Header("座標係數")]
    public Transform Leftpoint;
    public Transform Rightpoint;
    public float leftx;
    public float rightx;
    [Header("面向方向狀態係數")]
    public bool face = true;
    [Header("動畫判斷狀態")]
    public bool isjump;
    public bool isAttack;
    public bool isHurt;
    // Start is called before the first frame update
    void Awake()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        leftx = Leftpoint.position.x;
        rightx = Rightpoint.position.x;
    }

    // Update is called once per frame
   
}
