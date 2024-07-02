using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI percentage;

    private void Update()
    {
        // identify the transition between Scenes
        if (slider.value == 100 && MenuButton.sceneIndex() == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if (slider.value == 100 && MenuButton.sceneIndex() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }else if(slider.value == 100 && Door_Quit.door_use_to_quit)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // synchronise slider and percentage 
    public void Text()
    {
        percentage.text = slider.value + "%";
    }

}
