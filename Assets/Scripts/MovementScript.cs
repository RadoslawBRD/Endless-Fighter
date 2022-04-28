using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Vector2 moveInput;     
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + (moveInput * moveSpeed * Time.fixedDeltaTime));
        rb.AddForce(moveInput * Time.deltaTime);
    }
    void Update()
    {
        {
            //moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

}

