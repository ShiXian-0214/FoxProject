using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaglebasevalue : MonoBehaviour
{
    [Header("��¦����")]
    public Animator anime;
    public Rigidbody2D rb;
    [Header("�y�ЫY��")]
    public Transform Leftpoint;
    public Transform Rightpoint;
    public Transform stare;
    public float leftx;
    public float rightx;
    public float starey;
    [Header("���V��V���A�Y��")]
    public bool face = true;
    [Header("�ʵe�P�_���A")]
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
