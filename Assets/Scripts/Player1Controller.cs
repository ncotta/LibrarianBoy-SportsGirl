/*
 * Author(s): Niklaas Cotta
 * Last updated: 04/22/22
 * Controller for Player 1 game object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 0.5f;
    public float jumpThrust = 15f;
    private bool isGrounded;
    private int pickupCount;

    private Rigidbody rb;
    public TextMeshProUGUI gameOverText;

    public bool redKey = false;
    public bool blueKey = false;
    public bool greenKey = false;

    private bool interacting = false;
    private GameObject[] interactables;
    GameObject closest;
    float closestDist = 100f;
    string objectName;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupCount = 0;
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up, -10 * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up, 10 * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpThrust, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.E) && !interacting)
        {   
            interacting = true;

            foreach(GameObject interactable in interactables){
                float dist = Vector3.Distance(interactable.transform.position, gameObject.transform.position);
                if (dist < closestDist){
                    closest = interactable;
                    closestDist = dist;
                }
            }
            Debug.Log(closest);
            if (closestDist < 8.0f){
                if (closest.name == "Lever"){
                    Debug.Log("Interacting with lever");
                    closest.GetComponent<LeverScript>().Interact();
                }
                
            }
            StartCoroutine(Interact());
        }

    }

    IEnumerator Interact(){
        
        
        yield return new WaitForSeconds(0.5f);;
        interacting = false;
        Debug.Log("set it  to false");

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            pickupCount++;
        }

        if (other.gameObject.CompareTag("Ending"))
        {
            EndLevel();
        }
    }
    private void EndLevel()
    {
        gameOverText.enabled = true;
        Application.Quit();
    }
}