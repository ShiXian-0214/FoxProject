using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchAnime : MonoBehaviour
{
    // Start is called before the first frame update
    private basevalue basevalue;

    void Awake()
    {
        basevalue = GetComponent<basevalue>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnime();
    }

    public void SwitchAnime()
    {
        ResetAnime();
        basevalue.anime.SetFloat("runing", Mathf.Abs(basevalue.rb.velocity.x));
        
        if (basevalue.isGround&&!basevalue.isHurt)
        {
            basevalue.anime.SetBool("falling", false);

        }
        
        else if (!basevalue.isGround && !basevalue.isHurt && basevalue.rb.velocity.y > 0)
        {
            basevalue.anime.SetBool("jumping", true);

        }
        else if (basevalue.rb.velocity.y <= 0.1f && !basevalue.isHurt)
        {
            basevalue.anime.SetBool("jumping", false);
            basevalue.anime.SetBool("falling", true);

        }

        //趴下
        if (basevalue.isCrouch)
        {
            basevalue.anime.SetBool("Crouch", true);

        }
        else 
        {
            basevalue.anime.SetBool("Crouch", false);
        }
        //受傷
        if (!basevalue.isstairs) 
        {
            if (basevalue.isHurt)
            {
                basevalue.anime.SetBool("hurt", true);
                basevalue.anime.SetFloat("runing", 0);
                basevalue.anime.SetBool("jumping", false);
                basevalue.anime.SetBool("falling", false);
                basevalue.pcd.enabled = true;
                if (Mathf.Abs(basevalue.rb.velocity.x) < 0.1f)
                {
                    basevalue.anime.SetBool("hurt", false);
                    basevalue.isHurt = false;
                    basevalue.pcd.enabled = false;
                    basevalue.anime.SetFloat("runing", 0);
                    basevalue.anime.SetBool("jumping", false);
                    basevalue.anime.SetBool("falling", false);

                }
            }                 
        }
        else
        {
            basevalue.isstairs = true;
            basevalue.rb.velocity = new Vector2(0, basevalue.rb.velocity.y);
            basevalue.isHurt = false;
        }

        //攻擊
        if (basevalue.isAttack)
        {
            basevalue.anime.SetBool("Attack", true);

        }
        else 
        {
            basevalue.anime.SetBool("Attack", false);
        }
        //上下梯子切換
        if (basevalue.stairsmove)
        {
            basevalue.anime.SetBool("Stairsmove", true);
            basevalue.anime.SetBool("jumping", false);
            basevalue.anime.SetBool("falling", false);
            basevalue.anime.SetBool("hurt", false);
            basevalue.anime.SetBool("Attack", false);
            basevalue.anime.SetBool("Crouch", false);
        }
        else 
        {
            basevalue.anime.SetBool("Stairsmove", false);
        }
        if (basevalue.stairsstop)
        {
            basevalue.anime.SetBool("Stairsstop", true);
            basevalue.anime.SetBool("jumping", false);
            basevalue.anime.SetBool("falling", false);
            basevalue.anime.SetBool("hurt", false);
            basevalue.anime.SetBool("Attack", false);
            basevalue.anime.SetBool("Crouch", false);
        }
        else
        {
            basevalue.anime.SetBool("Stairsstop", false);
        }
    }
    private void ResetAnime() 
    {
        basevalue.anime.SetBool("jumping", false);
        basevalue.anime.SetBool("falling", false);
    }
   

}

