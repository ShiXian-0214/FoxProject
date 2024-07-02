using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    private basevalue basevalue;
    private void Awake()
    {
        basevalue = GetComponent<basevalue>();
    }
    public void Continue(){
        panel.SetActive(false);
        basevalue.isstop = false;
    }

    public void Upgrade()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void Setting()
    {
        
    }
    public void OnBackClicked()
    {
        panel.SetActive(false);
    }

    public void OnPauseClicked()
    {
            panel.SetActive(true);
    }

    /*public void QuitToTitle()
    {
        SceneManager.LoadScene("Menu");
        basevalue.Destroy = false;
    }*/
    
}
