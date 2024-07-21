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
        keyboardSettings.Jump += playerControl.Jump;
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
