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
    public event Action<bool> StairsUp;
    public event Action<bool> Attack;
    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal != 0)
        {
            Move.Invoke(Horizontal);
        }
        else
        {
            Move.Invoke(Horizontal);
        }
    }
    void Update()
    {
        OnUpdate();
    }
    private void OnUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        bool stairsUp = Input.GetButton("up");
        bool crouch = Input.GetButton("Crouch");
        bool attack = Input.GetButtonDown("Attack");

        if (jump)
        {
            if (!crouch)
            {
                Jump.Invoke(true);
            }
        }

        if (crouch)
        {
            if (!jump)
            {
                Crouch.Invoke(true);
            }
        }
        else
        {
            Crouch.Invoke(false);
        }

        if(stairsUp)
        {
            StairsUp.Invoke(true);
        }
        else
        {
            StairsUp.Invoke(false);
        }
        
        if (attack)
        {
            if (horizontal == 0)
            {
                Attack.Invoke(true);
            }
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
