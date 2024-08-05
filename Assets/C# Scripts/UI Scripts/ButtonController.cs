using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI textbox01;
    [SerializeField] TextMeshProUGUI textbox02;
    [SerializeField] basevalue basevalue;
    [SerializeField] collision ColliSionValue;
    [SerializeField] GameObject game;
    [SerializeField] Attack AttackValue;
    [SerializeField] PlayHPsystem HPValue;
    [SerializeField] GameObject CherryNumber;
    [SerializeField] bool CheckSkill;
    [SerializeField] int HPSkillNumber;
    [SerializeField] int DmageSkillNumber;
    [SerializeField] int SkillNumber;

    bool level_one_done;
    private void Awake()
    {
    }
    public void OnBackClicked()
    {
        panel.SetActive(false);
    }

    // Skill Set 1
    public void OnSkillset_1Clicked()
    {
        RestSkill();
        textbox01.text = "As you enhance your vitality, your health pool experiences a significant boost. Leveling up your HP grants you increased resilience, allowing you to withstand more damage in the face of adversity. Hp + 1";
        game = GameObject.Find("Skill_Set _1");
        //CherryValue�O�������ƶq
        if (ColliSionValue.CherryValue  >= 3)
        {
            CheckSkill = true;
            HPSkillNumber = 1;
            textbox02.text = "Upgradeable : YES";
        }
        else 
        {
            CheckSkill = false;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade";
        }   
    }

    public void OnSkillset_1_1Clicked()
    {
        RestSkill();
        textbox01.text = "With this advanced upgrade, not only does your health increase further, but your endurance reaches a new level of mastery. You'll find yourself enduring through challenging battles with greater stamina, ensuring prolonged survival in the toughest encounters. Hp + 1";
        game = GameObject.Find("Skill_Set _1.1");
        if (ColliSionValue.CherryValue >= 3 && level_one_done == true)
        {
            CheckSkill = true;
            HPSkillNumber = 2;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            CheckSkill = false;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade & Hp level 1 upgraded";
        }
    }

    /*public void OnSkillset_1_2Clicked()
    {
        textbox01.text = "";

        if (ColliSionValue.CherryValue >= 3)
        {
            SkillNumber = 1;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            textbox02.text = "Upgradeable : NO";
        }
    }*/

    // Skill Set 2
    public void OnSkillset_2Clicked()
    {
        RestSkill();
        textbox01.text = "Sharpen your combat skills to increase the power of your attacks. The level 1 upgrade in attack enhances your combat proficiency, dealing more damage to adversaries. Feel the surge of strength as you unleash devastating blows on your foes. Attack Damage + 2";
        game = GameObject.Find("Skill_Set _2");
        if (ColliSionValue.CherryValue >= 3)
        {
            DmageSkillNumber = 1;
            CheckSkill = true;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            CheckSkill = false;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade";
        }     
    }
    
    public void OnSkillset_2_1Clicked()
    {
        RestSkill();
        textbox01.text = "Ascend to the next level of mastery with your weapon of choice. The level 2 upgrade not only boosts your attack power but also unlocks mastery strikes. Execute intricate and powerful combos, overwhelming enemies with a dazzling display of skill and precision. Attack Damage + 4";
        game = GameObject.Find("Skill_Set _2.1");
        if (ColliSionValue.CherryValue >= 3 && level_one_done == true)
        {
            DmageSkillNumber = 2;
            CheckSkill = true;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            CheckSkill = false;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade & Attack level 1 upgraded";
        }
    }

    /*public void OnSkillset_2_2Clicked()
    {
        textbox01.text = "2.2";

        if (ColliSionValue.CherryValue >= 3)
        {
            SkillNumber = 2;
            textbox02.text = "OK2";
        }
        else
        {
            textbox02.text = "no2";
        }
    }*/

    // Skill Set 3
    public void OnSkillset_3Clicked()
    {
        RestSkill();
        textbox01.text = "Unlock the ability to perform a double jump, allowing you to reach higher platforms and evade obstacles with finesse. Master the art of the airborne leap to explore new areas and gain a tactical advantage in traversing the game world.";
        game = GameObject.Find("Skill_Set _3");
        if (ColliSionValue.CherryValue >= 3)
        {
            SkillNumber = 1;
            CheckSkill = true;
            textbox02.text = "Upgradeable : YES";
        }
        else
        {
            CheckSkill = false;
            textbox02.text = "Upgradeable : NO <br>Need 3 Cherry to Upgrade";
        }
      
    }

    //public void OnSkillset_3_1Clicked()
    //{
       
    //    textbox01.text = "Player's movement speed + 1 ";

    //    if (ColliSionValue.CherryValue >= 3)
    //    {
    //        SkillNumber = 5;
    //        textbox02.text = "OK3";
    //    }
    //    else
    //    {
    //        textbox02.text = "no3";
    //    }
    //}

    //public void OnSkillset_3_2Clicked()
    //{
    //    textbox01.text = "Player's movement speed + 2";

    //    if (ColliSionValue.CherryValue >= 3)
    //    {
    //        SkillNumber = 7;
    //        textbox02.text = "Upgradeable : YES";
    //    }
    //    else
    //    {
    //        textbox02.text = "Upgradeable : NO";
    //    }
    //}


    public void OnCheckerButton() 
    {
        if (HPSkillNumber == 1)
        {
            if (CheckSkill == true)
            {
                ColliSionValue.CherryValue = ColliSionValue.CherryValue - 3;
                HPValue.hp = 5;/*��q*/
                //HPValue.numofhearts = 5;/*���e��q*/
                game.GetComponent<Button>().interactable = false;
                level_one_done = true;

                textbox02.text = " ";
            }
            else { return; }


        }
        else if (HPSkillNumber == 2)
        {
            if (CheckSkill == true) 
            {
                ColliSionValue.CherryValue = ColliSionValue.CherryValue - 3;
                HPValue.hp = 7;/*��q*/
                //HPValue.numofhearts = 7;/*���e��q*/
                game.GetComponent<Button>().interactable = false;
                textbox02.text = " ";
            }
            else { return; }

        }
       
        else if (DmageSkillNumber == 1)
        {
            if (CheckSkill == true)
            {
                ColliSionValue.CherryValue = ColliSionValue.CherryValue - 3;
                AttackValue.Dmage = 3;/*�ˮ`��*/
                game.GetComponent<Button>().interactable = false;
                level_one_done = true;

                textbox02.text = " ";
            }
            else { return; }


        }
        else if (DmageSkillNumber == 2)
        {
            if (CheckSkill == true)
            {
                ColliSionValue.CherryValue = ColliSionValue.CherryValue - 3;
                AttackValue.Dmage = 7;/*�ˮ`��*/
                game.GetComponent<Button>().interactable = false;
                textbox02.text = " ";
            }
            else { return; }


        }
      
        else if (SkillNumber == 1)
        {
            if (CheckSkill == true)
            {
                ColliSionValue.CherryValue = ColliSionValue.CherryValue - 3;
                basevalue.JumpCountRest = 2;/*���D���ƪ����s*/
                basevalue.JumpCount = 2; /*���D����*/
                game.GetComponent<Button>().interactable = false;
                textbox02.text = " ";
            }
            else { return; }

           
        }
        RestSkill();
    }
    void RestSkill() 
    {
        ColliSionValue.CherryCount.text = ColliSionValue.CherryValue.ToString();
        HPSkillNumber = 0;
        DmageSkillNumber = 0;
        SkillNumber = 0;
    }
}
