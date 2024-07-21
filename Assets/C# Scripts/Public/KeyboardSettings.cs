using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KeyboardSettings : MonoBehaviour
{
    public event Action<bool> Jump;
   
    void Update()
    {
        OnUpdate();
    }
    private void OnUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if(horizontalMove!=0)
        {
            
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump.Invoke(true);
        }
        if (Input.GetButtonDown("Attack"))
        {
            //player.Attack();
        }
        if (Input.GetButtonDown("Crouch"))
        {
            //player.Crouch();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }

        if (Input.GetKeyDown(KeyCode.E) && Door_Quit.door_use_to_quit == true && Door_Quit.Takeshield == true)
        {

        }
    }
}
