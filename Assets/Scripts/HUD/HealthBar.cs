using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    public float currentHP;
    public float maxHp;
    public Slider healthDisplay;

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
    private void Start()
    {
        currentHP = maxHp;
        Debug.Log("HeathBar Created!!!");
    }

    public void SetHealth(float _health)
    {
        Debug.Log("set health " + _health);
        healthDisplay.value = _health;
    }
    public void updateMaxHp(float _value)
    {
        maxHp = _value;
    }
}
