using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float Damge;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayHPsystem>()?.EnemyTakeAttack(this);

            // play player hurt Event
            AudioManager.instance.PlayOneShot(FModEvents.instance.hurtEvent, this.transform.position);
        }
    }
}
