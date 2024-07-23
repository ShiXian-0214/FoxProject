using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFloW : MonoBehaviour
{
    [SerializeField] private KeyboardSettings keyboardSettings;
    [SerializeField] private PlayerControl playerControl;
    private void Awake()
    {
        keyboardSettings.Move += playerControl.Move;
        keyboardSettings.Jump += playerControl.Jump;
        keyboardSettings.Crouch += playerControl.Crouch;
        keyboardSettings.Attack+= playerControl.Attack;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
