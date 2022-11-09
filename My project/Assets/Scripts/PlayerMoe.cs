using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float speed;
    public float time;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //float j = Input.GetAxis("High");
        Vector3 movement = new Vector3(h * speed, rb.velocity.y, v * speed);
        rb.AddForce(movement);
    }
}
