using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonLabelModifier : MonoBehaviour
{
    // Start is called before the first frame update
    public Text current,bonus,change;    //aktualna statystyka, o ile siê zmieni, co siê zmieni



    void Start()
    {
        try
        {
            Debug.Log("Skill button "+this.gameObject.name+" created successfuly");
        }
        catch (Exception e)
        {
            Debug.LogError("Skill Manager had proboelms: " + e.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLabels(string _current, string _bonus, string _change)
    {
        current.text = _current;
        bonus.text = _bonus;
        change.text = _change;
    }
}
