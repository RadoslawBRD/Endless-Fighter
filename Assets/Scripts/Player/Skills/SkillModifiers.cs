using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModifiers : MonoBehaviour
{
    public static SkillModifiers instance;
    public Dictionary<int, string> skillTable = new Dictionary<int, string>();
    public float valueMultiplier = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            #region skillTable fill
            skillTable.Add(0, "MaxHealth");
            skillTable.Add(1, "MoveSpeed");
            skillTable.Add(2, "BasicAttackSpeed");
            skillTable.Add(3, "AddDamage");
            skillTable.Add(4, "BasicAttackRange");
            skillTable.Add(5, "HpRegen");
            skillTable.Add(6, "HpRegenRate");
            //skillTable.Add(7, "Health");
            //skillTable.Add(8, "Health");
            //skillTable.Add(9, "Health");


            //expReward
            //skillValueMultiplier


            #endregion

            Debug.Log("SkillModifiers enabled properly");

        }
        catch (System.Exception e)
        {
            Debug.Log("SkillModifiers not enabled!!" + e.Message);

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

    public void AddMaxHealth(float _value) => PlayerManager.instance.maxHealth += _value * valueMultiplier;
    public void AddMoveSpeed(float _value) => PlayerManager.instance.moveSpeed += _value * valueMultiplier;
    public void AddBasicAttackSpeed(float _value) => PlayerManager.instance.basicAttackSpeed -= _value * valueMultiplier;
    public void AddDamage(float _value) => PlayerManager.instance.basicDamage += _value * valueMultiplier;
    public void AddBasicAttackRange(float _value) => PlayerManager.instance.basicAttackRange += _value * valueMultiplier;
    public void IncreaseHpRegen(float _value) => PlayerManager.instance.healthRegen += _value * valueMultiplier;
    public void IncreaseHpRegenRate(float _value) => PlayerManager.instance.healthRegen -= _value * valueMultiplier;

    public string ApplyModifier(int _modifier, float _value)
    {
        switch (_modifier)
        {
            case 1:
                AddMaxHealth(_value);
                //return new string[] { "AddMaxHealth" };
                return "AddMaxHealth" ;
                break;
            case 2:
                AddMoveSpeed(_value);
                return "AddMoveSpeed";
                break;
            case 3:
                AddBasicAttackSpeed(_value);
                return "AddBasicAttackSpeed";
                break;
            case 4:
                AddDamage(_value);
                return "AddDamage";
                break;
            case 5:
                AddBasicAttackRange(_value);
                return "AddBasicAttackRange";
                break;
            case 6:
                IncreaseHpRegen(_value);
                return "IncreaseHpRegen";
                break;
            case 7:
                IncreaseHpRegenRate(_value);
                return "IncreaseHpRegenRate";
                break;
            case 8:
                return "";
                break;
            case 9:
                return "";
                break;
            default:
                return "";
                break;

        }
        Debug.Log("Skill numer: "+ _modifier+ " wartosci: "+ _value);
    }
    public string GetSkillData(int _modifier)
    {
        switch (_modifier)
        {
            case 1:
                return PlayerManager.instance.maxHealth.ToString();
            case 2:
                return PlayerManager.instance.moveSpeed.ToString();
            case 3:
                return PlayerManager.instance.basicAttackSpeed.ToString();
            case 4:
                return PlayerManager.instance.basicDamage.ToString();
            case 5:
                return PlayerManager.instance.basicAttackRange.ToString();
            case 6:
                return PlayerManager.instance.healthRegen.ToString();
            case 7:
                return PlayerManager.instance.healthRegenRate.ToString();
            case 8:
                return "";
            case 9:
                return "";
            default:
                return "";

        }
        Debug.Log("Dane skilla numer: " + _modifier);
    }


}
