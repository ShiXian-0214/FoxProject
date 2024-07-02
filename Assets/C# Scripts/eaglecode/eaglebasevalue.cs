using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaglebasevalue : MonoBehaviour
{
    [Header("基礎元件")]
    public Animator anime;
    public Rigidbody2D rb;
    [Header("座標係數")]
    public Transform Leftpoint;
    public Transform Rightpoint;
    public Transform stare;
    public float leftx;
    public float rightx;
    public float starey;
    [Header("面向方向狀態係數")]
    public bool face = true;
    [Header("動畫判斷狀態")]
    public bool isAttack;
    void Awake()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        leftx = Leftpoint.position.x;
        rightx = Rightpoint.position.x;      
        starey = stare.position.y;
    }
}
