using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController21 : MonoBehaviour
{
    int planeIndicator = 0;

    float speed = 10.0f;
    float planeAabsLimits = 10.0f;
    float planeBabsLimits = 5.0f;

    float relzLimit;
    float relxLimit;

    float gravityModifier = 2.0f;
    bool isGrounded = true;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Detect Player in planeA
        if (planeIndicator == 0)
        {
            //Boundary limits
            relzLimit = planeAabsLimits;
            relxLimit = planeAabsLimits;

            //Boundary limits for planeA Z-Axis
            if (transform.position.z > relzLimit)
            {
                if (transform.position.x > -relzLimit / 2 && transform.position.x < relxLimit / 2)
                {
                    transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
                }
            }
            else if (transform.position.z < -relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            }

            //Boundary limits for planeA X-Axis
            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            }
        }

        //Detect player in planeB
        else
        {
            relzLimit = planeAabsLimits + 2 * planeBabsLimits;
            relxLimit = planeBabsLimits;

            if (transform.position.z < planeAabsLimits)
            {
                if (transform.position.x > -planeAabsLimits / 2 && transform.position.x < planeAabsLimits / 2)
                {
                    transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, planeAabsLimits);
                }
            
            }
            else if (transform.position.z > relzLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, relzLimit);
            }
            else
            {
                transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            }

            if (transform.position.x > relxLimit)
            {
                transform.position = new Vector3(relxLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -relxLimit)
            {
                transform.position = new Vector3(-relxLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            }

            //make player jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Debug.Log("In Plane A");
            planeIndicator = 0;
        }

        if (collision.gameObject.CompareTag("PlaneB"))
        {
            Debug.Log("In Plane B");
            planeIndicator = 1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}









