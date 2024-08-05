using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    [SerializeField] private float Hp;
    [SerializeField] private float maxHp;
    [SerializeField] private Image[] hpUiImages;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite haifHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private float invincibleTimeValue;
    [SerializeField] private float RestInvincibleTimeValue;
    [SerializeField] private bool invincibleTime;
    private void Awake()
    {
        HpUi();
    }
    private void Update()
    {
        CalculateInvincibleTime();
    }
    public void Attack(float Damage)
    {
        CalculateDamage(Damage);
    }
    private void CalculateDamage(float Damage)
    {
        if (!invincibleTime)
        {
            invincibleTime=true;
            Hp -= Damage;
            HpUi();
        }
        else
        {
            return;
        }

    }
    private void HpUi()
    {
        if (Hp > maxHp)
        {
            Hp = maxHp;
        }
        for (int i = 0; i < hpUiImages.Length; i++)
        {
            if (i < Hp)
            {
                hpUiImages[i].sprite = fullHeart;
            }
            else if (i - Hp == 0.5)
            {
                hpUiImages[i - 1].sprite = haifHeart;
                hpUiImages[i].sprite = emptyHeart;
            }
            else
            {
                hpUiImages[i].sprite = emptyHeart;
            }
            if (i < maxHp)
            {
                hpUiImages[i].enabled = true;
            }
            else
            {
                hpUiImages[i].enabled = false;
            }
        }
    }
    private void CalculateInvincibleTime()
    {
        if(invincibleTimeValue<=0)
        {
            invincibleTime = false;
            invincibleTimeValue = RestInvincibleTimeValue;
        }
        if (invincibleTime)
        {
            invincibleTimeValue -= Time.deltaTime;
        }

    }
}
