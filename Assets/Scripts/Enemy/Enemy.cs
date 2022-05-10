using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    int id;
    private Rigidbody2D rb;
    public Vector2 target;
    private bool autoAttack = false;

    //Stats
    public float moveSpeed = 100f;
    public float health = 100f;
    float damage = 10f;
    float cashValue = 10f;
    float expValue = 10f;
    float maximumAproachDistance = 0.1f;

    float attackRange;
    public float attackSpeed = 15f;
    public float tempTime;

    
    void Start()
    {
        //initial stat setup
        id = EnemyManager.instance.id;
        attackRange = maximumAproachDistance + 0.1f;
        
        EnemyManager.instance.enemies.Add(id, this);


    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();

        }
        /*if (Vector2.Distance(GameManager.instance.playerPosition, this.transform.position) < attackRange)
        {
            Attack();
        }*/

    }
    private void FixedUpdate()
    {
        if (autoAttack)
        {
            tempTime += Time.fixedDeltaTime;
            if (tempTime*10 > attackSpeed)
            {
                tempTime = 0f;
                Attack();
            }
        }
        //target = (GameManager.instance.playerPosition - (Vector2)transform.position).normalized;

        //transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.playerPosition, 1f);
        try
        {
            if (Vector2.Distance(GameManager.instance.playerPosition, this.transform.position) > maximumAproachDistance)
                rb.AddForce(WherePlayer(GameManager.instance.playerPosition) * -1 * moveSpeed * Time.fixedDeltaTime); // -1 bo nie chce mi siê odwracaæ return w WherePlayer
        }
        catch
        {
            Debug.LogError("Problem z RigidBody: "+ id);
        }
    }

    
    private Vector2 WherePlayer(Vector2 _playerPosition)
    {
        if (this.transform.position.x >= _playerPosition.x && this.transform.position.y >= _playerPosition.y)
            return new Vector2(1, 1);
        if (this.transform.position.x <= _playerPosition.x && this.transform.position.y <= _playerPosition.y)
            return new Vector2(-1, -1);
        if (this.transform.position.x <= _playerPosition.x && this.transform.position.y >= _playerPosition.y)
            return new Vector2(-1, 1);
        if (this.transform.position.x >= _playerPosition.x && this.transform.position.y <= _playerPosition.y)
            return new Vector2(1, -1);
        return new Vector2(0, 0);

    }
    void Attack()
    {
        PlayerManager.instance.getDamage(damage);
        Debug.Log("Atakuje");

    }
    public void SetAutoAttack(bool _value)
    {
        autoAttack = _value;
    }
   
    public void getDamage(float _value)
    {
        health -= _value;
        if(health <= 0)
        {
            PlayerManager.instance.changeMoney(cashValue);
            PlayerManager.instance.addExp(expValue);

            EnemyManager.instance.enemies.Remove(id);
            Destroy(gameObject);
        }
        

    }
}
    

