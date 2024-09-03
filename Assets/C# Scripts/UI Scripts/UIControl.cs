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
    private bool gamePauseSwitch;
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
        Time.timeScale = 0;
        gamePauseSwitch = true;
        pauseUI.SetActive(true);
        playerHPUI.SetActive(false);
    }
    public void ClosePauseUI()
    {
        Time.timeScale = 1;
        gamePauseSwitch = false;
        playerHPUI.SetActive(true);
        pauseUI.SetActive(false);
        attributeUI.SetActive(false);
    }
    public bool GamePauseSwitch()
    {
        return gamePauseSwitch;
    }
    public void GetCherry()
    {
        cherryValue++;
        cherryCount.text = cherryValue.ToString();
    }
}
