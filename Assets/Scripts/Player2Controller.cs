using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 0.5f;
    public float jumpThrust = 15f;
    private bool isGrounded;
    private int pickupCount;
    public TextMeshProUGUI gameOverText;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        if (Input.GetKey(KeyCode.Keypad0) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpThrust, ForceMode.Impulse);
            isGrounded = false;
        }
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
    
    if (other.gameObject.CompareTag("Exit"))
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
