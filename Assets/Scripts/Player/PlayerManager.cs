using System.Collections;
using System.Collections.Generic;
using System;
using System.Timers;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public MovementScript mv;
    public Vector2 lastDir;
    RaycastHit2D _hit;


    private float timeAttack = 0;
    private float timeRegen = 0;

    public float health;
    float level = 0;
    public float exp = 0;
    private float cash = 0;
    public bool gameIsRunning = true;

    //Stats
    public float moveSpeed = 100f;
    public float maxHealth = 100;
    public float healthRegen = 0.05f;
    public float healthRegenRate = 2f;


    public float basicDamage = 100f;
    public float basicAttackRange= 2f;
    public float basicAttackSpeed = 1f;

    public float expModifier = 1f;
    public float nextLevelTarget = 100f;

    

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


    // Start is called before the first frame update

    void Start()
    {
        health = maxHealth;
        HealthBar.instance.updateMaxHp(maxHealth);
       // Physics2D.IgnoreLayerCollision(9, 10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            HudManager.instance.ChangeAbilitiesScreenVisibility();
            EnemyManager.instance.ChangeCanEnemyMove();

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))!= new Vector2(0,0))
            lastDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mv.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        GameManager.instance.playerPosition = this.transform.position;

        if (gameIsRunning)
        {
            timeAttack += Time.deltaTime;
            timeRegen += Time.deltaTime;

            if (timeAttack > basicAttackSpeed)
            {
                timeAttack = 0f;
                Attack();
            }
            if(timeRegen > healthRegenRate)
            {
                timeRegen = 0f;
                HealthRegen();
            }
        }
    }

    void Attack()
    {
        //basicAttack
        _hit = Physics2D.Raycast(transform.position, new Vector2(lastDir.x, 0), basicAttackRange);
        //Debug.DrawLine(transform.position, new Vector2(lastDir.x, 0), Color.red, 5f);
        Debug.DrawRay(transform.position, new Vector2(lastDir.x, 0) * 2, Color.red, 1f);
        //new Raycast(transform.position, lastDir.x, attackDistance, null, null);
        if (_hit.collider != null) { 
            if (_hit.collider.CompareTag("Enemy"))
                _hit.collider.gameObject.GetComponent<Enemy>().getDamage(basicDamage);
            Debug.Log(_hit.collider.gameObject.name);
        }
        
    }

    public void GetDamage(float _value)
    {
        if(gameIsRunning)
            health -= _value;
        UpdateHealth();
    }
    public float GetMoney() => cash;
    public void ChangeMoney(float _value)
    {
        if (_value < 0)
            cash -= _value;
        else
            cash += _value;
        CashDisplay.instance.UpdateCashDisplay(cash);
    }
    public void UpdateHealth()
    {
        HealthBar.instance.SetHealth(health);
    }
    public void UpdateExp()
    {
        ExpBar.instance.SetExp(exp);
    }

    public void AddExp(float _value) //wraz z expem roœnie poziom trudnoœci przeciwników!
    {
        exp += _value * expModifier;
        UpdateExp();
        if (exp >= nextLevelTarget)
            AddLevel();
    }
    public void AddLevel()
    {
        EnemyManager.instance.ChangeCanEnemyMove();
        exp = 0;
        level++;
        UpdateExp();
        HudManager.instance.ChangeLevelUpScreenVisibility();
        SkillsManager.instance.SelectSkillForButton();

        Debug.Log("Osi¹gniety lvl: " +level);
    }
    
    public void HealthRegen()
    {
        if(health<maxHealth)
            health += healthRegen;

        if (health > maxHealth)        
            health = maxHealth;        
    }



}
