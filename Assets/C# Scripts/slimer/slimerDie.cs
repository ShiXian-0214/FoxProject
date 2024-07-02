using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimerDie : MonoBehaviour
{
    hpsystem hpsystem;
    [SerializeField] Animator animator;
    [SerializeField] Canvas slimerHPUI;

    // Start is called before the first frame update
    void Start()
    {
        hpsystem = GetComponent<hpsystem>();
        animator =this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpsystem.hp <= 0)
        {
            animator.SetTrigger("death");
        }
        else
        {
            return;
        }
    }
    void SlimerDead() 
    {
        Destroy(gameObject);
        AudioManager.instance.PlayOneShot(FModEvents.instance.bossClear, this.transform.position);
        slimerHPUI.enabled = false;
        Victory.isBossDead = true;

        AudioManager.instance.SetMusicArea(MusicArea.SlimerDie);
    }

}
