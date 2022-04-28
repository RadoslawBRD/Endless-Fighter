using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
    int id;
    int nextId = 0;
    private Rigidbody2D rb;
    public Vector2 target;

        //Stats
    public float moveSpeed = 100f;
    public float health = 100f;
    float damage = 100f;
    float cashValue = 10f;
    float maximumAproachDistance = 0.5f;
    float attackRange;


    void Start()
    {
        //initial stat setup
        attackRange = maximumAproachDistance + 0.1f;

        id = nextId;
        nextId++; 
        enemies.Add(id, this);
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(GameManager.instance.playerPosition, this.transform.position) < attackRange)
        {
            Attack();
        }
    }
    private void FixedUpdate()
    {

        //target = (GameManager.instance.playerPosition - (Vector2)transform.position).normalized;

        //transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.playerPosition, 1f);
        if(Vector2.Distance(GameManager.instance.playerPosition, this.transform.position) > maximumAproachDistance)
         rb.AddForce(WherePlayer(GameManager.instance.playerPosition)*-1 * moveSpeed * Time.fixedDeltaTime); // -1 bo nie chce mi siê odwracaæ return w WherePlayer
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

    }
}
