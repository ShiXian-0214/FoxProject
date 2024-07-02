using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    basevalue basevalue;

    PlayHPsystem playerHpSystem;

    void Start()
    {
        basevalue = GetComponent<basevalue>();

        playerHpSystem = GetComponent<PlayHPsystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHpSystem.hp == 0)
        {
            basevalue.destroy = false;

            SceneManager.LoadScene("Dead Scene");

            AudioManager.instance.PlayOneShot(FModEvents.instance.deadEvent, this.transform.position);
        }
    }

}
