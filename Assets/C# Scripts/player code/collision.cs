using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    private basevalue basevalue;
    private hpsystem hpsystem;

    private plaerycon plaerycon;

    [Header("Äå®ç«Y¼Æ")]
    public int CherryValue;
    public Text CherryCount;
    public bool start;
    public bool check;
    public float time = 2;

    // Start is called before the first frame update
    void Awake()
    {
        basevalue.isboos = false;
        basevalue = GetComponent<basevalue>();
        hpsystem = GetComponent<hpsystem>();

        plaerycon = GetComponent<plaerycon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !basevalue.isAttack)
        {
            
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                basevalue.isHurt = true;
                basevalue.isJump = false;               
                basevalue.rb.velocity = new Vector2(-5, basevalue.rb.velocity.y);

              
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                basevalue.isHurt = true;
                basevalue.isJump = false;               
                basevalue.rb.velocity = new Vector2(5, basevalue.rb.velocity.y);                       
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Cherry")
        {
            Destroy(collision.gameObject);
            CherryValue++;
            //CherryCount.text = CherryValue.ToString();

            // play coinCollected Event
            AudioManager.instance.PlayOneShot(FModEvents.instance.coinCollectedEvent, this.transform.position);
        }
        if (collision.tag == "stairs")
        {
            basevalue.isstairs = true;
        }
        if (collision.tag == "door")
        {
            basevalue.opendoor = true;
        }*/

        switch (collision.tag) 
        {
            case "Cherry":            
                check = true;
                Destroy(collision.gameObject);
                CherryValue++;
                check = false;                           
                CherryCount.text = CherryValue.ToString();

                // play coinCollected Event
                AudioManager.instance.PlayOneShot(FModEvents.instance.coinCollectedEvent, this.transform.position);
                break;

            case "stairs":
                basevalue.isstairs = true;              
                break;

            case "door":
                basevalue.opendoor = true;
                break;

            case "door_quit" :
                Door_Quit.door_use_to_quit = true;
                break;
            case "shield":
                Door_Quit.Takeshield = true;
                AudioManager.instance.PlayOneShot(FModEvents.instance.shieldCollectedEvent, this.transform.position);
                Destroy(collision.gameObject);
                break;

            case "deadLine":
                StartCoroutine(playerDead());
                break;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.tag == "stairs")
        {
            basevalue.isstairs = false;
        }
        if (collision.tag == "door")
        {
            basevalue.opendoor = false;
        }*/

        switch(collision.tag)
        {
            case "stairs":
                basevalue.isstairs = false;               
                break;

            case "door":
                basevalue.opendoor = false;
                break;
            case "BossSwitch":
                basevalue.isboos = true;
                break;
            
        }

    }

    IEnumerator playerDead()
    {
        // delay 
        yield return new WaitForSeconds(0.5f);

        // destroy cameras 
        basevalue.destroy = false;

        //change scene to dead scene
        SceneManager.LoadScene("Dead Scene");

        AudioManager.instance.PlayOneShot(FModEvents.instance.deadEvent, this.transform.position);
    }

}
