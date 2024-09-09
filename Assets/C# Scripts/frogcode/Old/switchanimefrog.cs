using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchanimefrog : MonoBehaviour
{
    private evemy_frog_value value;
    private hpsystem hpsystem;
    public float RestAnimeTime;
    public float RestAnimeCount;

    // Start is called before the first frame update
    void Awake()
    {
        value = GetComponent<evemy_frog_value>();
        hpsystem = GetComponent<hpsystem>();
    }

    // Update is called once per frame
    void Update()
    {
        switchanimee();
        RestAnime();
    }

    void switchanimee()
    {
        if (hpsystem.isHurt)
        {
            value.anime.SetBool("Hurt", true);
        }
        else
        {
            value.anime.SetBool("Hurt", false);
        }

        if (value.isAttack == true)
        {
            value.anime.SetBool("attack", true);
        }
        else
        {
            value.anime.SetBool("attack", false);
        }

        if (value.isjump == true)
        {
            value.anime.SetBool("jumping", true);

            if (value.rb.velocity.y < 0)
            {
                value.isjump = false;
                value.anime.SetBool("jumping", false);
                value.anime.SetBool("falling", true);
            }
        }
        
        if (value.cd.IsTouchingLayers(value.Ground) && value.anime.GetBool("falling"))
        {
            value.anime.SetBool("falling", false);
        }

    }
    void RestAnime()
    {
        if (!value.isjump)
        {
            RestAnimeTime -= Time.deltaTime;
            if (RestAnimeTime <= 0)
            {
                value.anime.SetBool("jumping", false);
                value.anime.SetBool("falling", true);
                RestAnimeTime = RestAnimeCount;
            }
        }
    }
}
