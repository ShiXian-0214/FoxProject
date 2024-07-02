using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class DoNotDestoreCM : MonoBehaviour
{
    public CinemachineConfiner CM;
    public PolygonCollider2D pd;
    public PolygonCollider2D AirWall;
    public PolygonCollider2D AirWall2;
    //public CinemachineVirtualCamera CameraFollow;
    //public GameObject CameraFollowObject;
    public CinemachineVirtualCamera BossCM;
    private basevalue basevalue;
    //private int test = 8;
    
    private void Awake()
    {
       
        basevalue = GetComponent<basevalue>();
        

    }
    private void Update()
    {
        BossCM = GameObject.Find("BossCM")?.GetComponent<CinemachineVirtualCamera>();
        if (basevalue.isboos == true) 
        {
            //CameraFollowObject = GameObject.Find("slimer") as GameObject;
            //AirWall = GameObject.Find("AirWall")?.GetComponent<PolygonCollider2D>();
            AirWall2 = GameObject.Find("AirWall2")?.GetComponent<PolygonCollider2D>();
            AirWall2.GetComponent<PolygonCollider2D>().isTrigger = false;
            //AirWall.GetComponent<PolygonCollider2D>().isTrigger = false;

            BossCM.enabled = true;          
            //CameraFollow.m_Follow = CameraFollowObject.transform;
            //CameraFollow.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneDepth = 0;
            //CameraFollow.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = 0;
            //CameraFollow.m_Lens.OrthographicSize = 8;


            
        }     
        if (basevalue.destroy&& !Victory.isBossDead)
        {
            if (pd == null)
            {
                pd = GameObject.Find("back")?.GetComponent<PolygonCollider2D>();
                CM.m_BoundingShape2D = pd;
            }
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        
    }
    void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        if (basevalue.destroy)
        {
            pd = GameObject.Find("back")?.GetComponent<PolygonCollider2D>();           
            CM.m_BoundingShape2D = pd;
        }
        else 
        {
            return; 
        }
    }

}
