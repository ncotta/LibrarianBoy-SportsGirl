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
    public float forceMagnitude;
    public bool boxCollide = false;
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
    }

    protected void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.CompareTag("pushableBox"))
        {
            Rigidbody rb2 = other.collider.attachedRigidbody;
            boxCollide = true;

            if (rb2 != null)
            {
                Vector3 forceDirection = other.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }
    }

    protected void EndLevel()
    {
        //gameOverText.enabled = true;
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
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

        if (Input.GetKey(KeyCode.S))
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

        if (Input.GetKey(KeyCode.A))
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

        if (Input.GetKey(KeyCode.D))
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