using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    // ----------Player Events----------
    // assign Player Footstpes Event from FMod
    [field: Header("PlayerFootsteps")]
    [field: SerializeField] public EventReference playerFootstepsEvent { get; private set; }

    // assign Player Jump Event from FMod
    [field: Header("Jump Event")]
    [field: SerializeField] public EventReference jumpEvent { get; private set; }

    // assign Player Hurt Event from FMod
    [field: Header("Hurt Event")]
    [field: SerializeField] public EventReference hurtEvent { get; private set; }

    //assign Player Dead Event from FMod
    [field: Header("Dead Event")]
    [field: SerializeField] public EventReference deadEvent { get; private set; }
    

    // ----------Music----------
    //assign Background Music from FMod
    [field: Header("Background Music")]
    [field: SerializeField] public EventReference backgroundMusic { get; private set; }


    // ----------Sound Effects----------
    // assign coin Event from FMod
    [field: Header("Coic SFX")]
    [field: SerializeField] public EventReference coinCollectedEvent { get; private set; }

    // assign shield Event from FMod
    [field: Header("Shield SFX")]
    [field: SerializeField] public EventReference shieldCollectedEvent { get; private set; }

    // assign eagle's attack Event from FMod
    [field: Header("Eagle's attack")]
    [field: SerializeField] public EventReference eagleAttackEvent { get; private set; }

    // assign Slime's bullets Event from FMod
    [field: Header("Slime's bullets")]
    [field: SerializeField] public EventReference bulletsEvent { get; private set; }

    // assign Enemy Die Event from FMod
    [field: Header("Enemy Die")]
    [field: SerializeField] public EventReference enemyDie { get; private set; }

    // assign Victory Event from FMod
    [field: Header("Boss Clear")]
    [field: SerializeField] public EventReference bossClear { get; private set; }

    public static FModEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMod Events in the scene");
        }
        instance = this;
    }
}
