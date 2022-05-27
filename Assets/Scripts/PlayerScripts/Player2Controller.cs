/*
* Author(s): Niklaas Cotta, Kelly Schombert
* Last updated: 05/17/22
* Controller for Player 2 game object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : PlayerClass
{
    Animator m_Animator;
    AudioSource m_AudioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        pickupCount = 0;
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        isActive = false;
    }

    protected void OnTriggerEnter(Collider other)
    {
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
        if (isActive){
            bool IsWalking = false;
            m_Animator.SetBool("IsWalking", IsWalking);
            
            if (Input.GetKey(KeyCode.W))
            {
                m_Animator.SetBool("IsWalking", true);
                IsWalking = true;

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

            }

            if (Input.GetKey(KeyCode.S))
            {
                m_Animator.SetBool("IsWalking", true);
                IsWalking = true;

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

            }

            if (Input.GetKey(KeyCode.A))
            {
                m_Animator.SetBool("IsWalking", true);
                IsWalking = true;

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
                m_Animator.SetBool("IsWalking", true);
                IsWalking = true;

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
            
            if(IsWalking && isGrounded)
            {
                if(!m_AudioSource.isPlaying)
                {
                    m_AudioSource.Play();
                }
            } else
            {
                m_AudioSource.Stop();
            }



            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                m_Animator.SetTrigger("Jump");

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
                // Ray ray = new Ray(transform.position, Vector3.down);
                // RaycastHit hit;

                // if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Obstacle"))
                // {
                //     transform.localRotation = hit.transform.localRotation;
                // }
            }

        }
        if (r.normalized != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(r.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            if(isGrounded){
                // Debug.Log("adding velo");
                rb.velocity = r * 15f;
            }
            else{
                rb.velocity = new Vector3(r.x*10f, rb.velocity.y, r.z*10f);
            }
                r.x = r.y = r.z = 0f;
            }
        else if (isGrounded){
            rb.velocity = r;
        }
        r.x = r.y = r.z = 0f;
    }
}
