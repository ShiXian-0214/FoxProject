using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evemy_frog_value : MonoBehaviour
{
    [Header("��¦����")]
    public Animator anime;
    public Rigidbody2D rb;
    public CircleCollider2D cd;
    public LayerMask Ground;
    [Header("���D�Y��")]
    public float jumpforce;
    [Header("�y�ЫY��")]
    public Transform Leftpoint;
    public Transform Rightpoint;
    public float leftx;
    public float rightx;
    [Header("���V��V���A�Y��")]
    public bool face = true;
    [Header("�ʵe�P�_���A")]
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
