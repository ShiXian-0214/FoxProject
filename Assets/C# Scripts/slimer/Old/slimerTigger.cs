using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimerTigger : MonoBehaviour
{
    private slimerBaseValue baseValue;
    // Start is called before the first frame update
    void Awake()
    {
        baseValue = GameObject.Find("slimer").GetComponent<slimerBaseValue>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            baseValue.isplayer = true;
            baseValue.player = collision.gameObject;
        }
    }

}
