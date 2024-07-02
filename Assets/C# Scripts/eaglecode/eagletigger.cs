using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagletigger : MonoBehaviour
{
    private eaglebasevalue value;
    [SerializeField] float speed;

    void Awake()
    {
        value = GetComponent<eaglebasevalue>();
        Destroy(value.stare.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            value.isAttack = true;
            value.rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            value.rb.velocity = new Vector2(value.rb.velocity.x, -speed);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            value.isAttack = false;          
        }
            
    }
}
