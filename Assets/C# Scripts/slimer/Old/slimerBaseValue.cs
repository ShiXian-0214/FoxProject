using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimerBaseValue : MonoBehaviour
{
    [Header("��¦����")]
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
    [Header("�ʵe�P�_���A")]
    public bool isAttack;
    public bool isidlet;
    [Header("�p��ɶ�")]
    public float attackTime;
    public float idletime;
    [Header("�ɶ����s")]
    public float attackTimecount;
    public float idletimecount;
    [Header("��������")]
    public bool isplayer;
    public bool isplayRight;
    public bool isplayLeft;
    public bool isup;
    public bool isdown;


}
