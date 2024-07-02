using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basevalue : MonoBehaviour
{
    [Header("Basis Components")]
    public Animator anime;
    public Rigidbody2D rb;
    public CircleCollider2D cd;
    public BoxCollider2D box;
    public PolygonCollider2D pcd;
    public Transform groundChack;
    public Transform CrouchChack;
    public GameObject SceneMangerTransForm;
    public LayerMask ground;
    public GameObject panel;
    public GameObject pane2;
    public GameObject Player;
    public Canvas hp;

    [Header("Event trigger")]
    public bool opendoor;
    public static bool destroy = true;
    public bool SwitchSceneManger = false;

    [Header("Speed Coefficient")]
    public float speed;

    [Header("Jump Coefficient")]
    public int JumpCount;
    public int JumpCountRest;
    public float jumpforce;

    [Header("Attack Coefficient")]
    public int AttackCount;
    public int AttackCountRest;

    [Header("Button Control")]
    public bool jumpPressed;
    public bool Attackpressed;
    public bool Crouchpressed;
   

    [Header("Action identification")]
    public bool isstairs;
    public bool stairsstop;
    public bool stairsmove;
    public bool isGround;
    public bool isRuning;
    public bool isJump;
    public bool isCrouch;
    public bool isHurt;
    public bool isAttack;
    public static bool isstop;
    public static bool isboos;
    void Awake()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }
}

