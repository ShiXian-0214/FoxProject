using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFloW : MonoBehaviour
{
    [Header("baseObject")]
    [SerializeField] private KeyboardSettings keyboardSettings;
    [SerializeField] private UIControl uIControl;
    [SerializeField] private PauseController pauseController;
    [SerializeField] private GameObject Player;
    [SerializeField] private IPlayer playerControl;
    [SerializeField] private HpSystem hpSystem;

    [Header("GetObject")]
    [SerializeField] private PolygonCollider2D CameraBoundary;
    [SerializeField] private SlimerControl slimerControl;
    [SerializeField] private PolygonCollider2D BossAirWall_2;
    [SerializeField] private CinemachineVirtualCamera BossCamera;
    [SerializeField] private CinemachineConfiner cinemachineConfiner;
    [SerializeField] private GameObject DetectWalls;
    [SerializeField] private RetainOrRelease[] retainOrReleases;
    
    private static bool checkStatic = false;
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
        keyboardSettings.OpenPauseUI += uIControl.OpenPauseUI;
        keyboardSettings.ClosePauseUI += uIControl.ClosePauseUI;

        playerControl.GameOver += GameOver;
        playerControl.GetPoint += uIControl.GetCherry;
        playerControl.Boss_level += Boss_level;

        pauseController.ClosePauseUI += uIControl.ClosePauseUI;

        uIControl.buttonController.SetDamage += playerControl.SetDamage;
        uIControl.buttonController.SetJumpValue += playerControl.SetJumpValue;
        uIControl.buttonController.SetHPValue += hpSystem.SetHPValue;

        cinemachineConfiner.m_BoundingShape2D = CameraBoundary;
        
        GameStart();

    }
    private void GameStart()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!checkStatic)
        {
            
            checkStatic = true;
        }
        foreach (RetainOrRelease toke in retainOrReleases)
        {
            toke.GameStart();
        }
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
            if(obj.name == "back")
            {
                CameraBoundary = obj.GetComponent<PolygonCollider2D>();
                cinemachineConfiner.m_BoundingShape2D = CameraBoundary;
            }
            if (obj.name == "rebirth")
            {
                if (Player == null)
                {
                    Player = GameObject.FindWithTag("Player");
                    Player.transform.position = obj.transform.position;
                }
                else
                {
                    Player.transform.position = obj.transform.position;
                }
            }
            if (obj.name == "slimer")
            {
                slimerControl = obj.GetComponent<SlimerControl>();
                slimerControl.Player = Player;
            }
            if (obj.name == "BossCM")
            {
                BossCamera = obj.GetComponent<CinemachineVirtualCamera>();
            }
            if (obj.name == "DetectWalls")
            {
                DetectWalls = obj;
                if (DetectWalls != null)
                {
                    PolygonCollider2D[] airWalls = DetectWalls.GetComponentsInChildren<PolygonCollider2D>();
                    BossAirWall_2 = airWalls[1];
                }
            }
        }
    }
    private void Boss_level()
    {
        BossCamera.enabled = true;
        BossAirWall_2.isTrigger = false;
        slimerControl.init();

    }
    private void GameOver()
    {
        Destroy(this.gameObject);
        foreach (RetainOrRelease toke in retainOrReleases)
        {
            toke.GameOver();
        }
    }
}
