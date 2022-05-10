using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        
        if (collision.tag == "Player")
        {
            Debug.Log("SETAUTOATTACK TRUE");

            parent.GetComponent<Enemy>().SetAutoAttack(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collider");
        GetComponentInParent<Enemy>().SetAutoAttack(false);
    }
}
