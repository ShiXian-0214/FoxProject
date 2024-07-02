using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    private basevalue basevalue;
    // Start is called before the first frame update
    private void Awake()
    {
        basevalue = GetComponent<basevalue>();
        

    }
    private void Update()
    {
        if (basevalue.destroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        { 
            Destroy(this.gameObject); 
        }
                  
    }

}
