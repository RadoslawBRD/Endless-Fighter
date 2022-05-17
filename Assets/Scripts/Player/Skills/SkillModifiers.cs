using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModifiers : MonoBehaviour
{
    public static SkillModifiers instance;
    float valueMultiplier = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Debug.Log("SkillModifiers enabled properly");

        }
        catch (System.Exception e)
        {
            Debug.Log("Hud not enabled!!" + e.Message);

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
                return "AddMaxHealth";
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



}
