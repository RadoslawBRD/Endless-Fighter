using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillsManager : MonoBehaviour
{
    public Button buttonSkill1,buttonSkill2,buttonSkill3;



    // Start is called before the first frame update
    void Start()
    {
        buttonSkill1.onClick.AddListener(onClickSkill1);
        buttonSkill2.onClick.AddListener(onClickSkill2);
        buttonSkill3.onClick.AddListener(onClickSkill3);        
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

    public void SelectSkillForButton(Button btn)
    {

    }


}
