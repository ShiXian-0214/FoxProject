using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBaseValue : MonoBehaviour 
{
    [Header("BaseElement")]
    [SerializeField]protected Animator anime;
    [SerializeField]protected Rigidbody2D rb;

    [Header("CoordinateValue")]
    [SerializeField]protected Transform Leftpoint;
    [SerializeField]protected Transform Rightpoint;
    [SerializeField]protected float leftx;
    [SerializeField]protected float rightx;
    [Header("FaceDirection")]
    [SerializeField]protected bool face = true;
    [Header("AnimaBool")]
    [SerializeField]protected bool isAttack;

    public virtual void Move(){}
}
