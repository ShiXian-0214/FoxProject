using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimerControl : MonoBehaviour, IHpSystem
{
    private enum SlimerState
    {
        Attack,
        Idle
    }
    private enum PlayerDirection_X
    {
        Right,
        Left,

    }
    private enum PlayerDirection_Y
    {
        Up,
        Down
    }
    [SerializeField] private float attackTime;
    [SerializeField] private float idleTime;
    [SerializeField] private float restTime;
    [SerializeField] private SlimerAnimaControl slimerAnimaControl;
    [SerializeField] private SlimerState slimerState;
    [SerializeField] private Vector3 slimerTransform;
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private AnimaCallbackSet animaCallbackSet;
    [SerializeField] private PolygonCollider2D AttackColliderUnder;
    [SerializeField] private readonly float damage = 2;
    public GameObject Player;
    [SerializeField] private Vector3 playerTransform;
    [SerializeField] private PlayerDirection_X playerDirection_X;
    [SerializeField] private PlayerDirection_Y playerDirection_Y;
    [SerializeField] private bool StartSwitch = false;
    private void Awake()
    {
        slimerTransform = this.gameObject.GetComponent<Transform>().position;
        
    }
    private void Start()
    {
        animaCallbackSet.SetAnimationEvent(0,0.58f,Shooting);
        animaCallbackSet.SetAnimationEvent(0,0.5f,OpenAttackColliderUnder);
        animaCallbackSet.SetAnimationEvent(0,0.65f,OffAttackColliderUnder);
        animaCallbackSet.SetAnimationEvent(1,0.66f,slimerAnimaControl.SlimerDead);
        
    }
    public void init()
    {
        StartSwitch = true;
    }
    private void Update()
    {
        if (StartSwitch)
        {
            CheckPlayerDirection();
            switch (slimerState)
            {
                case SlimerState.Idle:
                    IdleTime();
                    slimerAnimaControl.IdleAnima();
                    break;

                case SlimerState.Attack:
                    AttackTime();
                    slimerAnimaControl.AttackAnima();
                    break;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            collision2D.gameObject.GetComponent<HpSystem>()?.Attack(damage);
        }
    }
    void Shooting()
    {
        if (playerDirection_Y == PlayerDirection_Y.Up && playerDirection_X == PlayerDirection_X.Left)
        {
            Instantiate(bullet[0], new Vector3(221, 0, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }
        else if (playerDirection_Y == PlayerDirection_Y.Up && playerDirection_X == PlayerDirection_X.Right)
        {
            Instantiate(bullet[1], new Vector3(225, 0, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }
        else if (playerDirection_Y==PlayerDirection_Y.Down&&playerDirection_X==PlayerDirection_X.Left)
        {
            Instantiate(bullet[2], new Vector3(220.09f, -6.11f, 0), Quaternion.identity);
            Instantiate(bullet[3], new Vector3(220.5f, -2.5f, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }
        else if (playerDirection_Y==PlayerDirection_Y.Down&&playerDirection_X==PlayerDirection_X.Right)
        {
            Instantiate(bullet[4], new Vector3(227.2f, -5.93f, 0), Quaternion.identity);
            Instantiate(bullet[5], new Vector3(226.5f, -2.5f, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }

    }
    void OpenAttackColliderUnder() 
    {
        AttackColliderUnder.enabled = true;
    }
    void OffAttackColliderUnder()
    {
        AttackColliderUnder.enabled = false;
    }
    

    public void Hurt(bool State) { }
    public void Dead()
    {
        slimerAnimaControl.DeadAnima();
    }
    private void CheckPlayerDirection()
    {
        playerTransform = Player.transform.position;
        if (playerTransform.x < slimerTransform.x)
        {
            playerDirection_X = PlayerDirection_X.Left;
        }
        else
        {
            playerDirection_X = PlayerDirection_X.Right;
        }
        if (playerTransform.y >= slimerTransform.y)
        {
            playerDirection_Y = PlayerDirection_Y.Up;
        }
        else
        {
            playerDirection_Y = PlayerDirection_Y.Down;
        }

    }
    private void IdleTime()
    {
        if (idleTime <= 0)
        {
            slimerState = SlimerState.Attack;
            idleTime = restTime;
        }
        else
        {
            idleTime -= Time.deltaTime;
        }

    }
    private void AttackTime()
    {
        if (attackTime <= 0)
        {
            slimerState = SlimerState.Idle;
            attackTime = restTime;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }



}
