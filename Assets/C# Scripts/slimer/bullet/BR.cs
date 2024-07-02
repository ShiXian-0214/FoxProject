using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tf;
    public float Timer;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        move();
        time();
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
        rb.velocity += new Vector2(0.1f, 0);
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
