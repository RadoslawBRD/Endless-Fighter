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
    private float tempTime;


    RaycastHit2D _hit;
        //Stats
    public float moveSpeed = 100f;
    public float maxHealth = 100;
    public float health;
    float damage = 100f;
    private float cash = 0;
    float attackDistance = 2f;
    float attackSpeed = 1f;
    float exp = 0;


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


    // Update is called once per frame
    void FixedUpdate()
    {
        if(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))!= new Vector2(0,0))
            lastDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mv.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        GameManager.instance.playerPosition = this.transform.position;

        if (true)
        {
            tempTime += Time.deltaTime;
            if (tempTime > attackSpeed)
            {
                tempTime = 0f;
                Attack();
            }
        }
    }

    void Attack()
    {
        //basicAttack
        _hit = Physics2D.Raycast(transform.position, new Vector2(lastDir.x, 0), attackDistance);
        //Debug.DrawLine(transform.position, new Vector2(lastDir.x, 0), Color.red, 5f);
        Debug.DrawRay(transform.position, new Vector2(lastDir.x, 0) * 2, Color.red, 1f);
        //new Raycast(transform.position, lastDir.x, attackDistance, null, null);
        if (_hit.collider != null) { 
            if (_hit.collider.CompareTag("Enemy"))
                _hit.collider.gameObject.GetComponent<Enemy>().getDamage(damage);
            Debug.Log(_hit.collider.gameObject.name);
        }
        
    }

    public void getDamage(float _value)
    {
        health -= _value;
        UpdateHealth();
    }
    public void changeMoney(float _value)
    {
        if (_value < 0)
            cash -= _value;
        else
            cash += _value;

    }
    public void UpdateHealth()
    {
        HealthBar.instance.SetHealth(health);
    }

    public void addExp(float _value) //wraz z expem roœnie poziom trudnoœci przeciwników!
    {
        exp += _value;
    }
    



}
