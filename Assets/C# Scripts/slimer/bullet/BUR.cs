using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUR : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform PlayTransform;
    public float Timer;
    void Update()
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
        if (PlayTransform.position.x>=226.5f&&PlayTransform.position.x<=229.5f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            rb.velocity += new Vector2(0.08f, 0);
        }
        else 
        {
            rb.velocity += new Vector2(0.08f, 0.05f);
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
