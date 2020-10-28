using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int planeIndicator = 0;

    float speed = 4.0f;
    float planeAabsLimits = 10.0f;
    float planeBasLimits = 5.0f;

    float boundaryLimit = 10.0f;
    float jumpForce = 8.0f;
    float moveForce = 8.0f;
    float gravityModifier = 1.2f;

     Rigidbody playerRb;

    float initYPos = 5;
    float nextYPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(planeIndicator == 0)
        {
            relzLimit = planeAabsLimits;
            relxLimit = planeAabsLimits;
        }

        if (transform.position.z < -boundaryLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundaryLimit);
        }
        else if (transform.position.z > boundaryLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundaryLimit);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveForce * verticalInput);
        }

        if (transform.position.x < -boundaryLimit)
        {
            transform.position = new Vector3(-boundaryLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundaryLimit)
        {
            transform.position = new Vector3(boundaryLimit, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveForce * horizontalInput);
        }

        jumpPlayer();
    }
    private void jumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("PlaneA"))
        }

    }
}
    


