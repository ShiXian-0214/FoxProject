using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    [Header("Volume Control")]
   
    // create variables for connecting these variables to FMod Bus in inspector
    [Range(0, 1)]
    public float masterVolume = 1;
   
    [Range(0, 1)]
    public float musicVolume = 1;
  
    [Range(0, 1)]
    public float SFXVolume = 1;


    // create Bus_variables for connect to FMod's Bus
    private Bus  masterBus;

    private Bus musicBus;

    private Bus SFXBus;


    private List<EventInstance> eventInstanceLists;

    private EventInstance backgroundMusicInstance;

    // to make this class into a singleton class (means there is only one of it at the time and all of the other scripts will be access this particular class)
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one AudioManager in the scene");
        }
        instance = this;

        eventInstanceLists = new List<EventInstance>();

        // assign FMod Bus to Bus_variables
        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        SFXBus = RuntimeManager.GetBus("bus:/SFX");
    }

    private void Start()
    {
        initializeMusic(FModEvents.instance.backgroundMusic);
    }

    private void Update()
    {

        // connect FMod Bus to variables
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        SFXBus.setVolume(SFXVolume);
    }

    // Create a Event to play the sound once and stop
    // EventReference sound : the Event which needed to play
    // Vector3 worldPos : where the Event will played from
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        // RuntimeManager : from FMODUnity
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstanceLists.Add(eventInstance);

        return eventInstance;
    }

    void initializeMusic(EventReference backgroundMusicReference)
    {
        backgroundMusicInstance = CreateInstance(backgroundMusicReference);
        backgroundMusicInstance.start();
    }

    public void SetMusicArea(MusicArea area)
    {
        backgroundMusicInstance.setParameterByName("area", (float) area);
    }

    void cleanUp()
    {
        // stop and release any create instance
        foreach (EventInstance eventInstance in eventInstanceLists)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        cleanUp();
    }

}
