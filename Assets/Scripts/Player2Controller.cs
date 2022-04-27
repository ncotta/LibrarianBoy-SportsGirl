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
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, -10 * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, 10 * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.RightControl) && isGrounded)
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
    }


}
