using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;

public class PlayHPsystem : MonoBehaviour
{
    [Header("�ͩR�Y��")]
    public Image[] imagehp;
    public Sprite haifheart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float HpMax;
    public float hp;
    [Header("�L�īY��")]
    public float invulnerbleDuration;
    private float invulnerbleCounter;
    public bool invulnerble;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        hpsystemcode();
        if (invulnerble)
        {
            invulnerbleCounter -= Time.deltaTime;
            if (invulnerbleCounter <= 0)
            {
                invulnerble = false;
            }
        }
    }
    public void hpsystemcode()
    {
        if (hp > HpMax)
        {
            hp = HpMax;
        }
        for (int i = 0; i < imagehp.Length; i++)
        {
            if (i < hp)
            {
                imagehp[i].sprite = fullHeart;
            }
            else if (i - hp == 0.5)
            {
                imagehp[i - 1].sprite = haifheart;
                imagehp[i].sprite = emptyHeart;
            }
            else
            {
                imagehp[i].sprite = emptyHeart;
            }
            if (i < HpMax)
            {
                imagehp[i].enabled = true;
            }
            else
            {
                imagehp[i].enabled = false;
            }
        }
    }
    public void Triggerinvulnerble()
    {
        if (!invulnerble)
        {
            invulnerble = true;
            invulnerbleCounter = invulnerbleDuration;
        }
    }
    public void EnemyTakeAttack(EnemyAttack attack)
    {
        if (invulnerble) return;
        hp -= attack.Damge;
        Triggerinvulnerble();
    }
}
