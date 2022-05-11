using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    public GameObject instructions;
    public bool displaying = false;

    void Start()
    {
        instructions.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SportsGirl") || other.gameObject.CompareTag("Librarian"))
        {
            instructions.gameObject.SetActive(true);
            displaying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SportsGirl") || other.gameObject.CompareTag("Librarian"))
        {
            instructions.gameObject.SetActive(false);
            displaying = false;
        }
    }
}
