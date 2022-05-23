using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillsManager : MonoBehaviour
{

    public static SkillsManager instance;

    public Button buttonSkill1,buttonSkill2,buttonSkill3;
    Dictionary<int, Button> guziki = new Dictionary<int, Button>();
    private float[,] skillValueHolder = new float[3,3];

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
            Debug.LogError("Skill Manager had proboelms: "+e.ToString());
        }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.Log("instance already exists, destroying object!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickSkill1()
    {
        string skillApplied = SkillModifiers.instance.ApplyModifier((int)skillValueHolder[0, 0], skillValueHolder[0, 1]);
        Debug.Log(skillApplied);
        GoBackToNormalGameplay();
    }
    public void onClickSkill2()
    {
        string skillApplied = SkillModifiers.instance.ApplyModifier((int)skillValueHolder[1, 0], skillValueHolder[1, 1]);
        Debug.Log(skillApplied);
        GoBackToNormalGameplay();
    }
    public void onClickSkill3()
    {
        string skillApplied = SkillModifiers.instance.ApplyModifier((int)skillValueHolder[2, 0], skillValueHolder[2, 1]);
        Debug.Log(skillApplied);
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
            int selectedSkill = random.Next(1, 7);
            int bonusForSkill = random.Next(-5, 5);

            TextForButtonWrapper(guziki[i], SkillModifiers.instance.GetSkillData(selectedSkill), (bonusForSkill * SkillModifiers.instance.valueMultiplier).ToString(),
                SkillModifiers.instance.skillTable[selectedSkill - 1]);

            skillValueHolder[i-1,0] = (float)selectedSkill;
            skillValueHolder[i-1,1] = (float)bonusForSkill;


           // changedSkill = SkillModifiers.instance.ApplyModifier(random.Next(1, 7), random.Next(-5, 5));
           // 
           //todo: jakoœ przej¹c te dane do funkcji wyzej

        }
    }
    public void TextForButtonWrapper(Button _btn, string _current, string _bonus, string _change)
    {
        _btn.GetComponent<SkillButtonLabelModifier>().SetLabels(_current, _bonus , _change);

    }



}
