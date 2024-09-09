using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private basevalue basevalue;

    public static int isFoward;
    static int num;
    public event Action DeleteObject;

    [SerializeField] Animator animator;

    private void Awake()
    {
        basevalue = GetComponent<basevalue>();
    }

    public void NewGame()
    {

        StartCoroutine(SceneChanged());

        isFoward = 1;

        basevalue.destroy = true;
        basevalue.isstop = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        basevalue.destroy = true;
        basevalue.isstop = false;

        SceneManager.LoadScene("Map1");
    }

    public void QuitToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingScene");

        isFoward = 0;

        basevalue.destroy = false;
        basevalue.isstop = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public static int sceneIndex()
    {
        if (isFoward == 1)
        {
            num = 1;
        }
        else if (isFoward == 0)
        {
            num = 0;
        }
        return num;
    }

    IEnumerator SceneChanged()
    {
        // run animation
        animator.SetBool("ButtonClicked", true);

        // delay the codes to complete animation
        yield return new WaitForSeconds(1.5f);

        // load scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
