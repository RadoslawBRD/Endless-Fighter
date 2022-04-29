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
    private Vector2 lastDir;

    RaycastHit2D _hit;
        //Stats
    public float moveSpeed = 100f;
    float maxHealth = 100;
    public float health;
    float damage = 100f;
    float money = 0;
    float attackDistance = 2f;

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
        aTimer.Enabled = true;


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))!= new Vector2(0,0))
            lastDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mv.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        GameManager.instance.playerPosition = this.transform.position;
    }
    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        Attack();
    }

    void Attack()
    {
        //basicAttack
         _hit = Physics2D.Raycast(transform.position, new Vector2(lastDir.x, 0), attackDistance);
        //new Raycast(transform.position, lastDir.x, attackDistance, null, null);
        if (_hit.collider.CompareTag("Enemy"));
            _hit.collider.gameObject.GetComponent<Enemy>().getDamage(damage);
        Debug.Log(_hit.collider.gameObject.name);


    }
    public void getDamage(float _value)
    {
        health -= _value;
    }



}
