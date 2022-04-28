using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject enemyPrefab;
    public Vector2 playerPosition;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateEnemy()
    {
     
        Instantiate(enemyPrefab, new Vector2(Random.Range(-20f,20f), Random.Range(-9f, 9f)), Quaternion.identity);
       // enemies.Add(nextId, new Enemy(new Vector2(2f, 3f)));
    }
}
