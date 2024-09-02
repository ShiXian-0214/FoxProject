using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetainOrRelease : MonoBehaviour
{
    public void GameStart()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void GameOver() 
    {
        Destroy(this.gameObject);
    }
}
