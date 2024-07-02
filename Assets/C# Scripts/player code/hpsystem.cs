using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpsystem : MonoBehaviour
{
    [Header("生命係數")]
    public Image[] imagehp;
    public Sprite haifheart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float numofhearts;
    public float hp;
    [Header("無敵係數")]
    public float invulnerbleDuration;
    private float invulnerbleCounter;
    public bool invulnerble;
    [Header("怪物生命UI")]
    public Canvas Canvas;
    public bool isHurt;

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
                Canvas.enabled = false;
                isHurt = false;
                invulnerble = false;
            }
        }
       
    }
    public void hpsystemcode()
    {
        if (hp > numofhearts) 
        {
            hp = numofhearts;
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


            if (i < numofhearts)
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
    public void TakeDamge(Attack attack) 
    {
        if (invulnerble) return;
        hp -= attack.Dmage;
        isHurt = true;
        Canvas.enabled = true;
        Triggerinvulnerble();
    }
    
}

