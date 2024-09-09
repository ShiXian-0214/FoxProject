using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeranime : MonoBehaviour
{
    private slimerBaseValue baseValue;
    // Start is called before the first frame update
    void Awake()
    {
        baseValue = GetComponent<slimerBaseValue>();
    }

    // Update is called once per frame
    void Update()
    {
        switchanime();
    }
    void switchanime() 
    {
        if (baseValue.isidlet) 
        {
            baseValue.anime.SetBool("idle", true);
            baseValue.anime.SetBool("attack", false);
        }
        if (baseValue.isAttack) 
        {
            baseValue.anime.SetBool("attack", true);
            baseValue.anime.SetBool("idle", false);
        }
    }
}
