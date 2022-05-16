using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModifiers : MonoBehaviour
{
    public static SkillModifiers instance;

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

    public void AddMaxHealth(float _value) => PlayerManager.instance.maxHealth += _value;
    public void AddMoveSpeed(float _value) => PlayerManager.instance.moveSpeed += _value;
    public void AddBasicAttackSpeed(float _value) => PlayerManager.instance.basicAttackSpeed -= _value;
    public void AddDamage(float _value) => PlayerManager.instance.basicDamage += _value;
    public void AddBasicAttackRange(float _value) => PlayerManager.instance.basicAttackRange += _value;
    public void IncreaseHpRegen(float _value) => PlayerManager.instance.healthRegen += _value;
    public void IncreaseHpRegenRate(float _value) => PlayerManager.instance.healthRegen -= _value;

    public void ApplyModifier(int _modifier, float _value)
    {
        switch (_modifier)
        {
            case 1:
                AddMaxHealth(_value);
                break;
            case 2:
                AddMoveSpeed(_value);
                break;
            case 3:
                AddBasicAttackSpeed(_value);
                break;
            case 4:
                AddDamage(_value);
                break;
            case 5:
                AddBasicAttackRange(_value);
                break;
            case 6:
                IncreaseHpRegen(_value);
                break;
            case 7:
                IncreaseHpRegenRate(_value);
                break;
            case 8:
                break;
            case 9:
                break;
            default:
                break;

        }
        Debug.Log("Skill numer: "+ _modifier+ " wartosci: "+ _value);
    }



}
