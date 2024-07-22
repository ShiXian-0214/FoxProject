using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KeyboardSettings : MonoBehaviour
{
    public event Action<bool> Jump;
    public event Action<float> Move;
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Move.Invoke(Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            Move.Invoke(Input.GetAxisRaw("Horizontal"));
        }
    }
    void Update()
    {
        OnUpdate();
    }
    private void OnUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump.Invoke(true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            //player.Crouch();
        }
        if (Input.GetButtonDown("Attack"))
        {
            //player.Attack();
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
