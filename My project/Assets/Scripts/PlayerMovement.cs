using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float speedup;
    public bool isOnGround = true;
    [SerializeField] public float packman; 

    Rigidbody rb;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
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
        rb.AddForce(Vector3.up * speedup, ForceMode.Impulse);
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (this.CompareTag("Player") && other.CompareTag("packman"))
        {
            packman++;
            Destroy(other.gameObject);

        }

    }

}

