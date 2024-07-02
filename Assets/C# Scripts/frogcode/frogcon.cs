using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogcon : MonoBehaviour
{
    private evemy_frog_value value;
    [SerializeField] float speed;
    

    void Awake()
    {
        value = GetComponent<evemy_frog_value>();
        Destroy(value.Leftpoint.gameObject);
        Destroy(value.Rightpoint.gameObject);
    }

    // Update is called once per frame
    void move()
    {
        if (value.face)
        {
            if (transform.position.x > value.leftx && value.cd.IsTouchingLayers(value.Ground))
            {
                value.isjump = true;
                value.rb.velocity = new Vector2(-speed, value.jumpforce);
            }
            if (transform.position.x < value.leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                value.face = false;
            }
        }
        else 
        {
            if (transform.position.x < value.rightx && value.cd.IsTouchingLayers(value.Ground)) 
            {
                value.isjump = true;
                value.rb.velocity = new Vector2(speed, value.jumpforce);
            }
            if (transform.position.x > value.rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                value.face = true;
            }

        }
    }
}
