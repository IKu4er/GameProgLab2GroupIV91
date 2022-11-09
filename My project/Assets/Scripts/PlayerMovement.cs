using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    

    Rigidbody rb;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RigidbodyJump();
        }
        
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(h * speed, 0, v * speed);
        rb.AddForce(movement);
    }
    private void RigidbodyJump()
    {
        rb.AddForce(Vector3.up * speed, ForceMode.VelocityChange);
    }

}

