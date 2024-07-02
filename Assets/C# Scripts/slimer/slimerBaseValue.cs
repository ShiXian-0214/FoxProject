using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimerBaseValue : MonoBehaviour
{
    [Header("基礎元件")]
    public Animator anime;
    public Rigidbody2D rb;
    public GameObject BDL;
    public GameObject BDR;
    public GameObject BUL;
    public GameObject BUR;
    public GameObject BR;
    public GameObject BL;
    public GameObject player;
    public PolygonCollider2D AttactCollider;
    [Header("動畫判斷狀態")]
    public bool isAttack;
    public bool isidlet;
    [Header("計算時間")]
    public float attackTime;
    public float idletime;
    [Header("時間重製")]
    public float attackTimecount;
    public float idletimecount;
    [Header("偵測角色")]
    public bool isplayer;
    public bool isplayRight;
    public bool isplayLeft;
    public bool isup;
    public bool isdown;


}
