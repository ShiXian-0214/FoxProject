using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI textbox01;
    [SerializeField] TextMeshProUGUI textbox02;

    [SerializeField] GameObject game;


    public event Func<int> CherryValue;
    public event Action<int> DeductCherryValue;
    public event Action<float> SetDamage;
    public event Action SetJumpValue;
    public event Action<float> SetHPValue;

    [SerializeField] private Skill skill;
    private enum Skill
    {
        HPSkill_level_1,
        HPSkill_level_2,
        AttackSkill_level_1,
        AttackSkill_level_2,
        jumpSkill,
        NoPoint
    }

    private Dictionary<Skill, bool> skillUnlockStatus = new Dictionary<Skill, bool>();
    private void Awake()
    {
        skillUnlockStatus.Add(Skill.HPSkill_level_2, false);
        skillUnlockStatus.Add(Skill.AttackSkill_level_2, false);
    }
    public void OnBackClicked()
    {
        panel.SetActive(false);
    }

    // Skill Set 1
    public void OnSkillset_1Clicked()
    {
        textbox01.text = "As you enhance your vitality, your health pool experiences a significant boost. Leveling up your HP grants you increased resilience, allowing you to withstand more damage in the face of adversity. Hp + 1";
        game = GameObject.Find("Skill_Set _1");

        if (CherryValue.Invoke() >= 3)
        {
            skill = Skill.HPSkill_level_1;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            skill = Skill.NoPoint;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade";
        }
    }

    public void OnSkillset_1_1Clicked()
    {
        textbox01.text = "With this advanced upgrade, not only does your health increase further, but your endurance reaches a new level of mastery. You'll find yourself enduring through challenging battles with greater stamina, ensuring prolonged survival in the toughest encounters. Hp + 1";
        game = GameObject.Find("Skill_Set _1.1");
        if (CherryValue.Invoke() >= 3 && skillUnlockStatus[Skill.HPSkill_level_2] == true)
        {
            skill = Skill.HPSkill_level_2;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            skill = Skill.NoPoint;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade & Hp level 1 upgraded";
        }
    }

    public void OnSkillset_2Clicked()
    {
        textbox01.text = "Sharpen your combat skills to increase the power of your attacks. The level 1 upgrade in attack enhances your combat proficiency, dealing more damage to adversaries. Feel the surge of strength as you unleash devastating blows on your foes. Attack Damage + 2";
        game = GameObject.Find("Skill_Set _2");
        if (CherryValue.Invoke() >= 3)
        {
            skill = Skill.AttackSkill_level_1;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            skill = Skill.NoPoint;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade";
        }
    }

    public void OnSkillset_2_1Clicked()
    {
        textbox01.text = "Ascend to the next level of mastery with your weapon of choice. The level 2 upgrade not only boosts your attack power but also unlocks mastery strikes. Execute intricate and powerful combos, overwhelming enemies with a dazzling display of skill and precision. Attack Damage + 4";
        game = GameObject.Find("Skill_Set _2.1");
        if (CherryValue.Invoke() >= 3 && skillUnlockStatus[Skill.AttackSkill_level_2] == true)
        {
            skill = Skill.AttackSkill_level_2;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            skill = Skill.NoPoint;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade & Attack level 1 upgraded";
        }
    }


    public void OnSkillset_3Clicked()
    {
        textbox01.text = "Unlock the ability to perform a double jump, allowing you to reach higher platforms and evade obstacles with finesse. Master the art of the airborne leap to explore new areas and gain a tactical advantage in traversing the game world.";
        game = GameObject.Find("Skill_Set _3");
        if (CherryValue.Invoke() >= 3)
        {
            skill = Skill.jumpSkill;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            skill = Skill.NoPoint;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade";
        }

    }


    public void OnCheckerButton()
    {
        switch (skill)
        {
            case Skill.NoPoint:
                break;

            case Skill.HPSkill_level_1:
                skillUnlockStatus[Skill.HPSkill_level_2] = true;
                UpgradeSkillHP(5f);

                break;

            case Skill.HPSkill_level_2:
                UpgradeSkillHP(7f);
                break;

            case Skill.AttackSkill_level_1:
                skillUnlockStatus[Skill.AttackSkill_level_2] = true;
                UpgradeSkillAttack(3);
                break;
            case Skill.AttackSkill_level_2:
                UpgradeSkillAttack(7);
                break;
            case Skill.jumpSkill:
                UpgradeSkillJump();
                break;
        }
    }
    private void UpgradeSkillHP(float number)
    {
        DeductCherryValue.Invoke(3);
        SetHPValue.Invoke(number);
        game.GetComponent<Button>().interactable = false;
        textbox02.text = " ";
        skill = Skill.NoPoint;
    }
    private void UpgradeSkillAttack(int number)
    {
        DeductCherryValue.Invoke(3);
        SetDamage.Invoke(number);
        game.GetComponent<Button>().interactable = false;
        textbox02.text = " ";
        skill = Skill.NoPoint;
    }
    private void UpgradeSkillJump()
    {
        DeductCherryValue.Invoke(3);
        SetJumpValue.Invoke();
        game.GetComponent<Button>().interactable = false;
        textbox02.text = " ";
        skill = Skill.NoPoint;
    }
}
