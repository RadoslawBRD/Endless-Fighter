using System.Collections;
using System.Collections.Generic;
using System;
using System.Timers;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public MovementScript mv;
    private static Timer aTimer;

        //Stats
    public float moveSpeed = 100f;
    float maxHealth = 100;
    public float health;
    float damage = 100f;
    float money = 0;

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

        aTimer = new System.Timers.Timer();
        aTimer.Interval = 2000; //ms
        aTimer.Elapsed += OnTimedEvent;

        aTimer.AutoReset = true;
        //aTimer.Enabled = true;


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        mv.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        GameManager.instance.playerPosition = this.transform.position;
    }
    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        Attack();
    }

    void Attack()
    {
        Debug.Log("atakuje");


    }
    public void getDamage(float _value)
    {
        health -= _value;
    }



}
