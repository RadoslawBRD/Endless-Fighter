using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector2 playerPosition;
    private Vector2 possibleSpawn;
    private bool autoSpawn = false;
    private float tempTime;
    private float minSpawnDistance = 15f;
    //game stats///
    float spawnRate = 1f; //1 sekunda

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
    void Start()
    {
        
       
        //InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        //druga opcja ciaglego spawnu co minute;
        if (autoSpawn)
        {
            tempTime += Time.deltaTime;
            if (tempTime > spawnRate)
            {
                tempTime = 0f;
                SpawnEnemy();
            }
        }




    }
    

  /*  public void CreateEnemy(bool _value)
    {
        if(_value)
            Instantiate(enemyPrefab, new Vector2(Random.Range(-20f,20f), Random.Range(-9f, 9f)), Quaternion.identity);
        else
            Instantiate(enemyPrefab, possibleSpawn, Quaternion.identity);

        // enemies.Add(nextId, new Enemy(new Vector2(2f, 3f)));
    }*/

    public void SwitchEnemySpawner()
    {
        if (autoSpawn)
            autoSpawn = false;
        else
            autoSpawn = true;
        Debug.Log(autoSpawn);
    }




    public void SpawnEnemy()
    {
        Vector2 _playerpos = PlayerManager.instance.transform.position;
        Vector2 _possibleSpawn = new Vector2(Random.Range(-20f, 20f), Random.Range(-9f, 9f)); 
        Debug.Log(_possibleSpawn +" "+ Vector2.Distance(_playerpos, _possibleSpawn));
        if (Vector2.Distance(_playerpos, _possibleSpawn) > minSpawnDistance) {
            EnemyManager.instance.SpawnEnemy(_possibleSpawn); //false /true okreœla Ÿród³o respienia przeciwnika
        }
        else
            SpawnEnemy();



    }
}
