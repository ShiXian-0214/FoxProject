using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float Damge;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HpSystem>()?.Attack(Damge);

            // play player hurt Event
            AudioManager.instance.PlayOneShot(FModEvents.instance.hurtEvent, this.transform.position);
        }
    }
}
