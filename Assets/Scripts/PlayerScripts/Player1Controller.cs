/*
 * Author(s): Niklaas Cotta
 * Last updated: 04/22/22
 * Controller for Player 1 game object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : PlayerClass
{
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupCount = 0;
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedPickup"))
        {
            other.gameObject.SetActive(false);
            pickupCount++;
        }

        if (other.gameObject.CompareTag("Ending"))
        {
            EndLevel();
        }

        if (other.gameObject.CompareTag("Death"))
        {
            EndLevel2();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // rb.AddForce(Vector3.forward.normalized * Time.deltaTime * speed * 10.0f, ForceMode.Impulse);
            // this.transform.Translate(Vector3.forward.normalized * Time.deltaTime * speed, Space.World);

            stopMovementFriction = false;
            if (r.x == -0.5f && r.z == -0.5f){
                r.x = -1f;
                r.z = 0f;
            }
            else if (r.x == 0.5f && r.z == 0.5f){
                r.x = 0f;
                r.z = 1f;
            }
            else{
                r.z = 0.5f;
                r.x = -0.5f;
            }
            // if (Vector3.forward.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.forward.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
        }

        if (Input.GetKey(KeyCode.S))
        {
            // rb.AddForce(Vector3.back.normalized * Time.deltaTime * speed * 10.0f, ForceMode.Impulse);
            // this.transform.Translate(Vector3.back.normalized * Time.deltaTime * speed, Space.World);
            stopMovementFriction = false;

            if (r.x == -0.5f && r.z == -0.5f){
                r.x = 0f;
                r.z = -1f;
            }
            else if (r.x == 0.5f && r.z == 0.5f){
                r.x = 1f;
                r.z = 0f;
            }
            else{
                r.z = -0.5f;
                r.x = 0.5f;
            }
            // if (Vector3.back.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.back.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
        }

        if (Input.GetKey(KeyCode.A))
        {
            // rb.AddForce(Vector3.left.normalized * Time.deltaTime * speed * 10.0f, ForceMode.Impulse);
            // this.transform.Translate(Vector3.left.normalized * Time.deltaTime * speed, Space.World);
            // if (Vector3.left.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.left.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
            stopMovementFriction = false;

            if (r.x == -0.5f && r.z == 0.5f){
                r.x = -1f;
                r.z = 0f;
            }
            else if (r.x == 0.5f && r.z == -0.5f){
                r.x = 0f;
                r.z = -1f;
            }
            else{
                r.z = -0.5f;
                r.x = -0.5f;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            // rb.AddForce(Vector3.right.normalized * Time.deltaTime * speed * 10.0f, ForceMode.Impulse);
            // this.transform.Translate(Vector3.right.normalized * Time.deltaTime * speed, Space.World);
            // if (Vector3.right.normalized != Vector3.zero)
            // {
            //     Quaternion toRotation = Quaternion.LookRotation(Vector3.right.normalized, Vector3.up);
            //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            // }
            stopMovementFriction = false;

            if (r.x == -0.5f && r.z == 0.5f){
                r.x = 0f;
                r.z = 1f;
            }
            else if (r.x == 0.5f && r.z == -0.5f){
                r.x = 1f;
                r.z = 0f;
            }
            else{
                r.z = 0.5f;
                r.x = 0.5f;
            }
        }

        if (r.normalized != Vector3.zero){
                Quaternion toRotation = Quaternion.LookRotation(r.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
                if(isGrounded){
                    rb.velocity = r * 15f;
                }
                else{
                    rb.velocity = new Vector3(r.x*10f, rb.velocity.y, r.z*10f);
                }
            r.x = r.y = r.z = 0f;
        }else if (isGrounded){
            rb.velocity = r;
        }



        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpThrust, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.E) && !interacting)
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