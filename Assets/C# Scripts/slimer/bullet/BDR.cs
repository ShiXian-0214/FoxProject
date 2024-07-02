using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDR : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform PlayTransform;
    public float Timer;
    private void Update()
    {
        move();
        time();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayTransform = collision.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "BossSwitch")
        {
            Destroy(this.gameObject);
        }
    }
    void move() 
    {
        if (PlayTransform.position.y <= -4)
        {
            rb.velocity += new Vector2(0.1f, -0.1f);
        }
        else 
        {
            rb.velocity += new Vector2(0.1f, 0);
        }
        
    }
    void time()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
