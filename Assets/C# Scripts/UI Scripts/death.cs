using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    private hpsystem hpsystem;
    private Animator animator;
    [Header("©Çª«¥Í©RUI")]
    [SerializeField] Canvas Canvas;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        hpsystem = GetComponent<hpsystem>();
    }
     void Update()
     {
        if (hpsystem.hp <= 0) 
        {
            animator.SetTrigger("death");
            //enemyDie(true);
        }
     }

    // Update is called once per frame
    void deathmonster()
    {
        Destroy(gameObject);
        Canvas.enabled = false;
        AudioManager.instance.PlayOneShot(FModEvents.instance.enemyDie, this.transform.position);
    }

    //void enemyDie(bool dieornot)
    //{
    //    if (dieornot == true)
    //    {
    //        //Canvas.enabled = false;

    //        //Destroy(gameObject);
            
    //    }
        
    //}
}
