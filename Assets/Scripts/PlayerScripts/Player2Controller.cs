using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : PlayerClass
{

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupCount = 0;
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BluePickup"))
        {
            other.gameObject.SetActive(false);
            pickupCount++;
        }

        if (other.gameObject.CompareTag("Ending"))
        {
            EndLevel();
        }
    }

    protected void EndLevel()
    {
        //gameOverText.enabled = true;
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // this.transform.Translate(Vector3.forward.normalized * Time.deltaTime * speed, Space.World);
            stopMovementFriction = false;

            if (r.x == 1f)
            {
                r.x = 0.5f;
                r.z = 0.5f;
            }
            else if (r.x == -1f)
            {
                r.x = -0.5f;
                r.z = 0.5f;
            }
            else
            {
                r.z = 1f;
            }
            // if (Vector3.forward.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.forward.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // this.transform.Translate(Vector3.back.normalized * Time.deltaTime * speed, Space.World);
            stopMovementFriction = false;
            if (r.x == 1f)
            {
                r.x = 0.5f;
                r.z = -0.5f;
            }
            else if (r.x == -1f)
            {
                r.x = -0.5f;
                r.z = -0.5f;
            }
            else
            {
                r.z = -1f;
            }
            // if (Vector3.back.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.back.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // this.transform.Translate(Vector3.left.normalized * Time.deltaTime * speed, Space.World);
            // if (Vector3.left.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.left.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
            stopMovementFriction = false;
            if (r.z == 1f)
            {
                r.x = -0.5f;
                r.z = 0.5f;
            }
            else if (r.z == -1f)
            {
                r.x = -0.5f;
                r.z = -0.5f;
            }
            else
            {
                r.x = -1f;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // this.transform.Translate(Vector3.right.normalized * Time.deltaTime * speed, Space.World);
            // if (Vector3.right.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.right.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
            stopMovementFriction = false;
            if (r.z == 1f)
            {
                r.x = 0.5f;
                r.z = 0.5f;
            }
            else if (r.z == -1f)
            {
                r.x = 0.5f;
                r.z = -0.5f;
            }
            else
            {
                r.x = 1f;
            }
        }

        if (r.normalized != Vector3.zero){
                Quaternion toRotation = Quaternion.LookRotation(r.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
                if(isGrounded){
                    rb.velocity = r * 20f;
                }
                else{
                    rb.velocity = new Vector3(r.x*10f, rb.velocity.y, r.z*10f);
                }
            r.x = r.y = r.z = 0f;
        }else if (isGrounded){
            rb.velocity = r;
        }

        if (Input.GetKey(KeyCode.Slash) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpThrust, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.RightShift) && !interacting)
        {
            interacting = true;
            Interact();
            StartCoroutine(InteractDelay());
        }

        if (isGrounded)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Obstacle"))
            {
                transform.localRotation = hit.transform.localRotation;
            }
        }
    }
}
