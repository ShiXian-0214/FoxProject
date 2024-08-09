using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    [SerializeField] private float Hp;
    [SerializeField] private float maxHp;
    [SerializeField] private GameObject currentGameObject;
    [SerializeField] private Canvas hpUi = null;
    [SerializeField] private Image[] hpUiImages;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite haifHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private float invincibleTimeValue;
    [SerializeField] private float RestInvincibleTimeValue;
    [SerializeField] private bool invincibleTime;

    private IHpSystem iHPSystem;
    private void Awake()
    {
        iHPSystem = currentGameObject.GetComponent<IHpSystem>();
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
            OpenHpUI();
            invincibleTime = true;
            Hp -= Damage;
            HpUi();
            if (Hp <= 0)
            {
                iHPSystem.Dead();
                hpUi.enabled = false;
            }
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
    private void OpenHpUI()
    {
        if (hpUi != null)
        {
            hpUi.enabled = true;
            StartCoroutine(CloseHpUI());
        }
    }
    private IEnumerator CloseHpUI()
    {
        yield return new WaitForSeconds(1.5f);
        if (hpUi != null)
        {
            hpUi.enabled = false;
        }

    }
    private void CalculateInvincibleTime()
    {
        if (invincibleTimeValue <= 0)
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
