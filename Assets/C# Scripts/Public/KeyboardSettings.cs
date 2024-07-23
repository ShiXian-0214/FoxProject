using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KeyboardSettings : MonoBehaviour
{
    public event Action<bool> Jump;
    public event Action<float> Move;
    public event Action<bool> Crouch;
    public event Action<bool> Attack;
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
        if (Input.GetButton("Crouch"))
        {
            Crouch.Invoke(true);
        }
        else
        {
            Crouch.Invoke(false);
        }
        if (Input.GetButtonDown("Attack"))
        {
            Attack.Invoke(true);
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
