using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject playerHPUI;
    [SerializeField] private GameObject attributeUI;

    [SerializeField] private int cherryValue;
    [SerializeField] private Text cherryCount;
    public ButtonController buttonController;
    private void Awake()
    {
        buttonController.CherryValue += CherryValue;
        buttonController.DeductCherryValue+=DeductCherryValue;
    }
    private int CherryValue()
    {
        return cherryValue;
    }
    private void DeductCherryValue(int number)
    {
        cherryValue = cherryValue-number;
        cherryCount.text = cherryValue.ToString();
    }

    public void OpenPauseUI()
    {
        pauseUI.SetActive(true);
        playerHPUI.SetActive(false);
    }
    public void ClosePauseUI()
    {
        playerHPUI.SetActive(true);
        pauseUI.SetActive(false);
        attributeUI.SetActive(false);
    }
    public void GetCherry()
    {
        cherryValue++;
        cherryCount.text = cherryValue.ToString();
    }
}
