using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimercon : MonoBehaviour
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
        switchmove();
        checkplayerdiretion();


    }
   
    void idletaime() 
    {
        if (!baseValue.isidlet) return;
        baseValue.idletime -= Time.deltaTime;;
    }
    void attackTime()
    {
        if (!baseValue.isAttack) return;
        baseValue.attackTime -= Time.deltaTime;
    }
    void switchmove() 
    {
        if (baseValue.isplayer)
        {
            if (baseValue.isidlet)
            {
                idletaime();
                if (baseValue.idletime <= 0)
                {
                    baseValue.isidlet = false;
                    baseValue.isAttack = true;
                    baseValue.idletime = baseValue.idletimecount;
                }
            }
            else if (baseValue.isAttack)
            {
                attackTime();              
                
                if (baseValue.attackTime <= 0)
                {
                    baseValue.isAttack = false;
                    baseValue.isidlet = true;
                    baseValue.attackTime = baseValue.attackTimecount;
                }

            }
            else
            {
                baseValue.isidlet = true;

            }

        }


    }
    void bubu()
    {
        if (baseValue.isup && baseValue.isplayRight)
        {
            Instantiate(baseValue.BUR, new Vector3(225, 0, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }       
        else if (baseValue.isup && baseValue.isplayLeft)
        {
            Instantiate(baseValue.BUL, new Vector3(221, 0, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }
        else if (baseValue.isdown && baseValue.isplayRight)
        {
            Instantiate(baseValue.BDR, new Vector3(226.5f, -2.5f, 0), Quaternion.identity);
            Instantiate(baseValue.BR, new Vector3(227.2f, -5.93f, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }
        else if (baseValue.isdown && baseValue.isplayLeft)
        {
            Instantiate(baseValue.BDL, new Vector3(220.5f, -2.5f, 0), Quaternion.identity);
            Instantiate(baseValue.BL, new Vector3(220.09f, -6.11f, 0), Quaternion.identity);
            AudioManager.instance.PlayOneShot(FModEvents.instance.bulletsEvent, this.transform.position);
        }

    }
    void checkplayerdiretion()
    {
        if (baseValue.player.transform.position.x >= this.gameObject.transform.position.x)
        {
            baseValue.isplayLeft = false;
            baseValue.isplayRight = true;
            if (baseValue.player.transform.position.y >= this.transform.position.y)
            {
                baseValue.isup = true;
                baseValue.isdown = false;
            }
            else if (baseValue.player.transform.position.y <= this.transform.position.y)
            {
                baseValue.isdown = true;
                baseValue.isup = false;
            }
        }
        else if (baseValue.player.transform.position.x <= this.gameObject.transform.position.x)
        {
            baseValue.isplayLeft = true;
            baseValue.isplayRight = false;
            if (baseValue.player.transform.position.y >= this.transform.position.y)
            {
                baseValue.isup = true;
                baseValue.isdown = false;
            }
            else if (baseValue.player.transform.position.y <= this.transform.position.y)
            {
                baseValue.isdown = true;
                baseValue.isup = false;
            }
        }


    }
    void AttackCollider() 
    {
        baseValue.AttactCollider.enabled = true;
    }
    void OffAttackCollider()
    {
        baseValue.AttactCollider.enabled = false;
    }
}
