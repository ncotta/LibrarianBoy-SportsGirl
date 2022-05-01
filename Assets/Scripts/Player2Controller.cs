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
            this.transform.Translate(Vector3.forward.normalized * Time.deltaTime * speed, Space.World);
            if (Vector3.forward.normalized != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back.normalized * Time.deltaTime * speed, Space.World);
            if (Vector3.back.normalized != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.back.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left.normalized * Time.deltaTime * speed, Space.World);
            if (Vector3.left.normalized != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.left.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right.normalized * Time.deltaTime * speed, Space.World);
            if (Vector3.right.normalized != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.right.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            }
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
