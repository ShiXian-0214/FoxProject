using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFloW : MonoBehaviour
{
    [SerializeField] private KeyboardSettings keyboardSettings;
    [SerializeField] private GameObject Player;
    [SerializeField] private IPlayer playerControl;
    private void Awake()
    {
        playerControl = Player.GetComponent<PlayerControl>();
        keyboardSettings.Move += playerControl.Move;
        keyboardSettings.Jump += playerControl.Jump;
        keyboardSettings.Crouch += playerControl.CrouchAndStairsDown;
        keyboardSettings.Attack += playerControl.Attack;
        keyboardSettings.StairsUp+=playerControl.StairsUp;
    }
}
