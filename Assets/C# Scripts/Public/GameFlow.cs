using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFloW : MonoBehaviour
{
    [SerializeField] private KeyboardSettings keyboardSettings;
    [SerializeField] private GameObject Player;
    [SerializeField] private IPlayer playerControl;
    private Transform test;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        playerControl = Player.GetComponent<IPlayer>();
        keyboardSettings.Move += playerControl.Move;
        keyboardSettings.Jump += playerControl.Jump;
        keyboardSettings.Crouch += playerControl.CrouchAndStairsDown;
        keyboardSettings.Attack += playerControl.Attack;
        keyboardSettings.StairsUp += playerControl.StairsUp;
        keyboardSettings.SwitchMap += SwitchMap;
    }
    private void SwitchMap()
    {
        if (playerControl.SwitchMap)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }
    }
    void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Scene scene2 = SceneManager.GetSceneByName(SceneManager.GetActiveScene().name);
        GameObject[] rootObjects = scene2.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            if (obj.name == "rebirth")
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                Player.transform.position = obj.transform.position;
            }
        }
    }
}
