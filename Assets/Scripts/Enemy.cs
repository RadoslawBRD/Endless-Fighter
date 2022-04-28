using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
    int id;
    int nextId = 0;
    float moveSpeed = 100f;
    private Rigidbody2D rb;
    public Vector2 target;


        void Start()
    {
        id = nextId;
        nextId++; 
        enemies.Add(id, this);
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        //target = (GameManager.instance.playerPosition - (Vector2)transform.position).normalized;

        //transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.playerPosition, 1f);
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
}
