using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public static bool isBossDead;

    [SerializeField] GameObject gameClear;

    private void Start()
    {
        isBossDead = false;
    }

    private void Update()
    {
        BossDie();
    }

    void BossDie()
    {
        if (isBossDead == true)
        {
            gameClear.SetActive(true);
        }
    }
}
