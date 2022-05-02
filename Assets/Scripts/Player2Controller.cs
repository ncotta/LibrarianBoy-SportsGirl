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
            if (r.x == 1f){
                r.x = 0.5f;
                r.z = 0.5f;
            }
            else if (r.x == -1f){
                r.x = -0.5f;
                r.z = 0.5f;
            }
            else{
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
            this.transform.Translate(Vector3.back.normalized * Time.deltaTime * speed, Space.World);
            if (r.x == 1f){
                r.x = 0.5f;
                r.z = -0.5f;
            }
            else if (r.x == -1f){
                r.x = -0.5f;
                r.z = -0.5f;
            }
            else{
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
            this.transform.Translate(Vector3.left.normalized * Time.deltaTime * speed, Space.World);
            // if (Vector3.left.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.left.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
            if (r.z == 1f){
                r.x = -0.5f;
                r.z = 0.5f;
            }
            else if (r.z == -1f){
                r.x = -0.5f;
                r.z = -0.5f;
            }
            else{
                r.x = -1f;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right.normalized * Time.deltaTime * speed, Space.World);
            // if (Vector3.right.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.right.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
            if (r.z == 1f){
                r.x = 0.5f;
                r.z = 0.5f;
            }
            else if (r.z == -1f){
                r.x = 0.5f;
                r.z = -0.5f;
            }
            else{
                r.x = 1f;
            }
        }

        if (r.normalized != Vector3.zero){
                Quaternion toRotation = Quaternion.LookRotation(r.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
                r.x = r.y = r.z = 0f;
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
    }


}
