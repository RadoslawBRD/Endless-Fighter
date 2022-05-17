using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillsManager : MonoBehaviour
{
    public Button buttonSkill1,buttonSkill2,buttonSkill3;
    Dictionary<int, Button> guziki = new Dictionary<int, Button>();


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            buttonSkill1.onClick.AddListener(onClickSkill1);
            buttonSkill2.onClick.AddListener(onClickSkill2);
            buttonSkill3.onClick.AddListener(onClickSkill3);

            guziki.Add(1, buttonSkill1);
            guziki.Add(2, buttonSkill2);
            guziki.Add(3, buttonSkill3);

            Debug.Log("Skill Manager created successfuly");
        }
        catch(Exception e)
        {
            Debug.Log("Skill Manager had proboelms: "+e.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickSkill1()
    {
        Debug.Log("guzik1");
        GoBackToNormalGameplay();
    }
    public void onClickSkill2()
    {
        Debug.Log("guzik2");
        GoBackToNormalGameplay();
    }
    public void onClickSkill3()
    {
        Debug.Log("guzik3");
        GoBackToNormalGameplay();
    }
    public void GoBackToNormalGameplay()
    {
        HudManager.instance.ChangeLevelUpScreenVisibility();
        EnemyManager.instance.ChangeCanEnemyMove();
    }

    public void SelectSkillForButton()
    {
        System.Random random = new System.Random();
        string changedSkill="";
        for (int i = 1; i <= 3 ; i++)
        {
            changedSkill = SkillModifiers.instance.ApplyModifier(random.Next(1, 7), random.Next(-5, 5));
            TextForButtonWrapper(guziki[i],)
                //todo: jakoœ przej¹c te dane do funkcji wyzej

        }


    }
    public void TextForButtonWrapper(Button _btn, string _current, string _bonus, string _change)
    {
        _btn.GetComponent<SkillButtonLabelModifier>().SetLabels(_current, _bonus, _change);
    }



}
