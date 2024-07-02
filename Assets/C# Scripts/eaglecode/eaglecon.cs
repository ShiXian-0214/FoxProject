using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaglecon : MonoBehaviour
{
    private eaglebasevalue value;
    [SerializeField] float speed;

    void Awake()
    {
        value = GetComponent<eaglebasevalue>();
        Destroy(value.Leftpoint.gameObject);
        Destroy(value.Rightpoint.gameObject);
    }

    // Update is called once per frame
    void move()
    {
       
        if (value.face)
        {

            if (transform.position.x > value.leftx)
            {
                value.rb.velocity = new Vector2(-speed, 0);

            }
            if (transform.position.x < value.leftx)
            {
                value.rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                value.face = false;
            }
        }
        else 
        {
            if (transform.position.x < value.rightx) 
            {
                value.rb.velocity = new Vector2(speed, 0);
            }
            if (transform.position.x > value.rightx) 
            {
                value.rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                value.face = true;
            }
        }
        if (!value.isAttack) 
        {          
            if (transform.position.y < value.starey) 
            {
                value.rb.velocity = new Vector2(value.rb.velocity.x, 5);
            }
            if (transform.position.y >= value.starey)
            {
               
                gameObject.transform.position = new Vector2(transform.position.x, value.starey);
                value.rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }
   
}
