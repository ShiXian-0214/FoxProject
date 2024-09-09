using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchanime : MonoBehaviour
{
    private eaglebasevalue value;
    private hpsystem hpsystem;
    void Awake()
    {
        value = GetComponent<eaglebasevalue>();
        hpsystem = GetComponent<hpsystem>();
    }

    // Update is called once per frame
    void Update()
    {
        animeSwitch();
    }
    void animeSwitch() 
    {
        if (value.isAttack)
        {
            value.anime.SetBool("attack", true);
            AudioManager.instance.PlayOneShot(FModEvents.instance.eagleAttackEvent, this.transform.position);
        }
        else 
        {
            value.anime.SetBool("attack", false);
        }
        if (hpsystem.isHurt) 
        {
            value.anime.SetBool("Hurt", true);
        }
        else
        {
            value.anime.SetBool("Hurt", false);
        }
    }
}
