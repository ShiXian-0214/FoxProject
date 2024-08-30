using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFloW : MonoBehaviour
{
    [SerializeField] private KeyboardSettings keyboardSettings;
    [SerializeField] private UIControl uIControl;
    [SerializeField] private PauseController pauseController;
    [SerializeField] private GameObject Player;
    [SerializeField] private IPlayer playerControl;
    [SerializeField] private HpSystem hpSystem;
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
        keyboardSettings.OpenPauseUI +=uIControl.OpenPauseUI;
        keyboardSettings.ClosePauseUI+=uIControl.ClosePauseUI;

        playerControl.GameOver += GameOver;
        playerControl.GetPoint+=uIControl.GetCherry;

        pauseController.ClosePauseUI+=uIControl.ClosePauseUI;

        uIControl.buttonController.SetDamage+=playerControl.SetDamage;
        uIControl.buttonController.SetJumpValue+= playerControl.SetJumpValue;
        uIControl.buttonController.SetHPValue+= hpSystem.SetHPValue;

    }
    private void SwitchMap()
    {
        if (playerControl.SwitchMap)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }
    }
    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
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
    private void GameOver()
    {
        Destroy(this.gameObject);
    }
}
