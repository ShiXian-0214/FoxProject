using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] GameObject thanks;
    [SerializeField] GameObject button;

    private void Start()
    {
        StartCoroutine(delay());
    }

    // delay
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        thanks.SetActive(true);

        yield return new WaitForSeconds(2f);
        button.SetActive(true);
    }

    /*void OnButtonClicked()
    {
        SceneManager.LoadScene();
    }*/
}
