using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update


    public  MovementScript mv;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mv.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GameManager.instance.playerPosition = this.transform.position;
    }            

}
