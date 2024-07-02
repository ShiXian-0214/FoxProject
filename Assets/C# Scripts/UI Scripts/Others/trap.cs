using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rigidbody2D;
    [SerializeField] BoxCollider2D BoxCollider2D;
    [SerializeField] PolygonCollider2D PolygonCollider2D;
    // Start is called before the first frame update
    private void Awake()
    {
        Rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        BoxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        PolygonCollider2D = this.gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                Rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                Rigidbody2D.velocity = new Vector2(0, -0.1f);  
                break;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Ground":
                Destroy(this.gameObject);
                break;
            case "Player":
                Destroy(this.gameObject);
                break;
            case "Enemy":
                Destroy(this.gameObject);
                break;

        }
    }
}
