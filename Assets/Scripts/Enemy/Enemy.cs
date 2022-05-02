using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
    int id;
    int nextId = 0;
    private Rigidbody2D rb;
    public Vector2 target;
    private static Timer aTimer;

    //Stats
    public float moveSpeed = 100f;
    public float health = 100f;
    float damage = 10f;
    float cashValue = 10f;
    float maximumAproachDistance = 0.5f;
    float attackRange;
    float attackSpeed = 1000f;

    void Start()
    {
        //initial stat setup
        attackRange = maximumAproachDistance + 0.1f;
        aTimer = new System.Timers.Timer();
        aTimer.Interval = attackSpeed; //ms
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;

        id = nextId;
        nextId++;
        enemies.Add(id, this);
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector2.Distance(GameManager.instance.playerPosition, this.transform.position) < attackRange)
        {
            Attack();
        }*/

    }
    private void FixedUpdate()
    {

        //target = (GameManager.instance.playerPosition - (Vector2)transform.position).normalized;

        //transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.playerPosition, 1f);
        if (Vector2.Distance(GameManager.instance.playerPosition, this.transform.position) > maximumAproachDistance)
            rb.AddForce(WherePlayer(GameManager.instance.playerPosition) * -1 * moveSpeed * Time.fixedDeltaTime); // -1 bo nie chce mi siê odwracaæ return w WherePlayer
    }

    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        Attack();
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

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            aTimer.Enabled = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        aTimer.Enabled = false;

    }
    public void getDamage(float _value)
    {
        health -= _value;
        if(health <= 0)
        {
            PlayerManager.instance.changeMoney(cashValue);
        }

    }
}
    

