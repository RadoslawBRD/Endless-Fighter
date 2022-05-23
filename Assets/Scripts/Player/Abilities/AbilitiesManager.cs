using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesManager : MonoBehaviour
{
    public static AbilitiesManager instance;
    public Button buttonAbility1, buttonAbility2, buttonAbility3;
    Dictionary<int, Button> guzikiAbilities = new Dictionary<int, Button>();


    float tempTime;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            buttonAbility1.onClick.AddListener(onClickAbility1);




            guzikiAbilities.Add(0, buttonAbility1);


            guzikiAbilities[0].GetComponentInChildren<Text>().text = "VerticalAttack: 50";

            
            Debug.Log("Abilities Manager created successfuly");
        }
        catch (Exception e)
        {
            Debug.LogError("Abilities Manager had problems: " + e.ToString());
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
    void FixedUpdate()
    {
        if (PlayerManager.instance.gameIsRunning)
        {
            tempTime += Time.deltaTime;

            if (AbilityHolder.instance.abilities[0].activationTime < tempTime)
            {
                tempTime = 0f;
                PlayerManager.instance.gameObject.GetComponent<AbilityHolder>().abilities[0].Activate(PlayerManager.instance.gameObject);
            }

        }
    }

    public void onClickAbility1()
    {
        if (PlayerManager.instance.GetMoney() >= 50f)
        {
            AbilityHolder.instance.abilities[0].isActive = true;
            HudManager.instance.ChangeAbilitiesScreenVisibility();
            buttonAbility1.enabled = false;
        }
    }
    


}
