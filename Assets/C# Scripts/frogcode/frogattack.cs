using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogattack : MonoBehaviour
{
    private evemy_frog_value value;
    void Awake()
    {
        value = GetComponent<evemy_frog_value>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            value.isAttack = true;
        }
    }
    void turnoffattack() 
    {
        value.isAttack = false;
    }
}
