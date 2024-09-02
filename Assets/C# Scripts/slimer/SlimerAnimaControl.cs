using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimerAnimaControl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void AttackAnima()
    {
        animator.SetBool("attack",true);
        animator.SetBool("idle",false);
    }
    public void IdleAnima()
    {
        animator.SetBool("attack",false);
        animator.SetBool("idle",true);
    }
    public void DeadAnima()
    {
        animator.SetTrigger("death");
    }
    public void SlimerDead() 
    {
        Destroy(gameObject);
        AudioManager.instance.PlayOneShot(FModEvents.instance.bossClear, this.transform.position);
        Victory.isBossDead = true;
        AudioManager.instance.SetMusicArea(MusicArea.SlimerDie);
    }
}
