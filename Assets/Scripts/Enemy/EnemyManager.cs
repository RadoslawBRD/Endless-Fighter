using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyManager instance;

    //prefabs
    public GameObject basicEnemyPrefab;


    public bool canEnemyMove = true;

    public Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
    public int id;
    int nextId = 0;
     

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(Vector2 _possibleSpawn )
    {

        id = nextId;
        nextId++;

        Instantiate(basicEnemyPrefab, _possibleSpawn, Quaternion.identity);

    }
    public void ChangeCanEnemyMove()
    {
        canEnemyMove = !canEnemyMove;
    }
}
