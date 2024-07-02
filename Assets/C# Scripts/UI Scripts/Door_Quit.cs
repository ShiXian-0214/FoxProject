using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Quit : MonoBehaviour
{
    public static bool door_use_to_quit; // assign by collision.cs plaerycon.cs Loading.cs
    public static bool Takeshield;
    [SerializeField] GameObject door_object;
    [SerializeField] GameObject shield;

    private void Awake()
    {

        door_object.SetActive(false);      
    }

    // Update is called once per frame
    void Update()
    {
        doorActive();
    }

    void doorActive()
    {
        if (Victory.isBossDead == true)
        {        
            if (shield == null)
            {
                door_object.SetActive(true);
            }
            else 
            {
                shield.SetActive(true);
               
            }
           
        }

    }
}
