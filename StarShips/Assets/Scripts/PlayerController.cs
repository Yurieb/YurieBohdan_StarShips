using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    
{
    private Rigidbody playerRD;
    private float speed = 140.0f;
    private float zBound = 20;


    // Start is called before the first frame update
    void Start()
    {
        playerRD = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRD.AddForce(Vector3.forward * speed * verticalInput);
        playerRD.AddForce(Vector3.right * speed * horizontalInput);
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);

        }
    }
    //
        

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Player has collided with rock");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
        }
    }



  

}
